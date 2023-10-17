using UnityEngine;

namespace Assets.Scripts.Player
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
            Vector2 scaledMovement = _gameModel.Player.Speed * _gameModel.Input.Direction;
            _view.Rigidbody.velocity = scaledMovement;
            _gameModel.Player.Position = _view.transform.position;
        }
    }
}