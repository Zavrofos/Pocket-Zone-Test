using Assets.Scripts.Controllers;
using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class StarterGame : MonoBehaviour
    {
        private GameModel _gameModel;
        private GameView _gameView;

        private List<IPresenter> _presenters;

        private List<IUpdater> _updaters;
                

        private void Awake()
        {
            _gameModel = new GameModel();
            _gameView = GetComponent<GameView>();

            _presenters = new List<IPresenter>
            {
                new JoystickPresenter(_gameModel, _gameView.Joystick),
            };

            _updaters = new List<IUpdater>
            {
                new CharacterMovementUpdater(_gameModel, _gameView.PlayerView),
            };
        }

        private void Update()
        {
            foreach(var updater in _updaters)
            {
                updater.Update(Time.deltaTime);
            }
        }

        private void OnEnable()
        {
            foreach(var controller in _presenters)
            {
                controller.Subscribe();
            }
        }

        private void OnDisable()
        {
            foreach (var controller in _presenters)
            {
                controller.Unsubscribe();
            }
        }
    }
}
