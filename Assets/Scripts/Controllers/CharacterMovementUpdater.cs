using Assets.Scripts.Models;
using Assets.Scripts.Views;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class CharacterMovementUpdater : IUpdater
    {
        private readonly GameModel _gameModel;
        private readonly PlayerView _view;

        public CharacterMovementUpdater(GameModel gameModel, PlayerView view)
        {
            _gameModel = gameModel;
            _view = view;
        }

        public void Update(float deltaTime)
        {
            Vector2 scaledMovement = _view.Speed * deltaTime * _gameModel.Input.Direction;
            _view.CharacterController.Move(scaledMovement);
        }
    }
}