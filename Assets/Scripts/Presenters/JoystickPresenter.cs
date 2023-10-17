using Assets.Scripts.Views;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using ETouch = UnityEngine.InputSystem.EnhancedTouch;

namespace Assets.Scripts.Presenters
{

    public class JoystickPresenter : IPresenter
    {
        private readonly GameModel _gameModel;
        private readonly JostickView _view;

        public JoystickPresenter(GameModel gameModel, JostickView view)
        {
            _gameModel = gameModel;
            _view = view;
        }

        public void Subscribe()
        {
            EnhancedTouchSupport.Enable();
            ETouch.Touch.onFingerDown += HandleFingerDown;
            ETouch.Touch.onFingerUp += HandleLoseFinger;
            ETouch.Touch.onFingerMove += HandleFingerMove;
        }

        public void Unsubscribe()
        {
            ETouch.Touch.onFingerDown -= HandleFingerDown;
            ETouch.Touch.onFingerUp -= HandleLoseFinger;
            ETouch.Touch.onFingerMove -= HandleFingerMove;
            EnhancedTouchSupport.Disable();
            _view.MovementFinger = null;

        }

        private void HandleFingerMove(Finger movedFinger)
        {
            if (movedFinger != _view.MovementFinger)
            {
                return;
            }

            Vector2 knobPosition;
            float maxMovement = _view.JoystickSize.x / 2f;
            ETouch.Touch currentTouch = movedFinger.currentTouch;

            if (Vector2.Distance(currentTouch.screenPosition, _view.RectTransform.anchoredPosition) > maxMovement)
            {
                knobPosition = (currentTouch.screenPosition - _view.RectTransform.anchoredPosition).normalized * maxMovement;
            }
            else
            {
                knobPosition = currentTouch.screenPosition - _view.RectTransform.anchoredPosition;
            }

            _view.Knob.anchoredPosition = knobPosition;
            _gameModel.Input.Direction = knobPosition / maxMovement;
        }

        private void HandleLoseFinger(Finger lostFinger)
        {
            if (lostFinger != _view.MovementFinger)
            {
                return;
            }

            _view.MovementFinger = null;
            _view.Knob.anchoredPosition = Vector2.zero;
            _view.gameObject.SetActive(false);
            _gameModel.Input.Direction = Vector2.zero;
        }

        private void HandleFingerDown(Finger touchedFinger)
        {
            if (_view.MovementFinger != null || touchedFinger.screenPosition.x > Screen.width / 2f)
            {
                return;
            }

            _view.MovementFinger = touchedFinger;
            _view.gameObject.SetActive(true);
            _view.RectTransform.sizeDelta = _view.JoystickSize;
            _view.RectTransform.anchoredPosition = ClampStartPosition(touchedFinger.screenPosition);
            _gameModel.Input.Direction = Vector2.zero;
        }

        private Vector2 ClampStartPosition(Vector2 startPosition)
        {
            if (startPosition.x < _view.JoystickSize.x / 2)
            {
                startPosition.x = _view.JoystickSize.x / 2;
            }

            if (startPosition.y < _view.JoystickSize.y / 2)
            {
                startPosition.y = _view.JoystickSize.y / 2;
            }
            else if (startPosition.y > Screen.height - _view.JoystickSize.y / 2)
            {
                startPosition.y = Screen.height - _view.JoystickSize.y / 2;
            }

            return startPosition;
        }
    }
}