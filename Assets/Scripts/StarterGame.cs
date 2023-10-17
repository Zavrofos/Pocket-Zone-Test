using Assets.Scripts.Camera;
using Assets.Scripts.Enemy;
using Assets.Scripts.Input;
using Assets.Scripts.Player;
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
                new EnemyInitializePresenter(_gameModel, _gameView),
                new CreatingEnemyPresenter(_gameModel, _gameView)
            };

            _updaters = new List<IUpdater>
            {
                new CharacterMovementUpdater(_gameModel, _gameView.PlayerView),
                new CameraMoveUpdater(_gameModel, _gameView.CameraView)
            };
        }

        private void Start()
        {
            _gameModel.Initialize();
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
