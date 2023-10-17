using UnityEngine;

namespace Assets.Scripts.Camera
{
    public class CameraMoveUpdater : IUpdater
    {
        private GameModel _gameModel;
        private CameraView _view;

        public CameraMoveUpdater(GameModel gameModel, CameraView view)
        {
            _gameModel = gameModel;
            _view = view;
        }

        public void Update(float deltaTime)
        {
            if (_view.IsMove)
            {
                Vector2 newPosition = Vector3.MoveTowards(_view.Transform.position,
                    _gameModel.Player.Position, _view.SmoothSpeed * Time.deltaTime);
                _view.Transform.position = new Vector3(newPosition.x, newPosition.y, -10);

                _view.IsMove = ((Vector2)_gameModel.Player.Position - newPosition).magnitude > 0.2f;
            }
            else
            {
                _view.IsMove = _gameModel.Player.Position.x > _view.Transform.position.x + _view.WindowSize.x ||
                _gameModel.Player.Position.x < _view.Transform.position.x - _view.WindowSize.x ||
                _gameModel.Player.Position.y > _view.Transform.position.y + _view.WindowSize.y ||
                _gameModel.Player.Position.y < _view.Transform.position.y - _view.WindowSize.y;
            }
        }
    }
}