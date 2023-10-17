using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyInitializePresenter : IPresenter
    {
        private GameModel _gameModel;
        private GameView _gameView;

        public EnemyInitializePresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }

        public void Subscribe()
        {
            _gameModel.Initialized += OnInitialize;
        }

        public void Unsubscribe()
        {
            _gameModel.Initialized -= OnInitialize;
        }

        private void OnInitialize()
        {
            foreach (var point in _gameView.PositionsToSpawnEnemies)
            {
                _gameModel.EnemyCollection.PositiontsToSpawnEnemies.Add(point.position);
            }

            for(int i = 0; i < 3; i++)
            {
                var positiontsToSpawnEnemies = _gameModel.EnemyCollection.PositiontsToSpawnEnemies;
                var index = Random.Range(0, positiontsToSpawnEnemies.Count);
                var position = positiontsToSpawnEnemies[index];
                positiontsToSpawnEnemies.Remove(position);
                _gameModel.EnemyCollection.CreateEnemy("Enemy", position);
            }
        }
    }
}