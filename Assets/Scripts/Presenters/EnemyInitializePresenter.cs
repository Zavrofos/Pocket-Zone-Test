using Assets.Scripts.Enums;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Scripts.Presenters
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

            //for(int i = 0; i < 3; i++)
            //{
            //    var positiontsToSpawnEnemies = _gameModel.EnemyCollection.PositiontsToSpawnEnemies;
            //    var index = Random.Range(0, positiontsToSpawnEnemies.Count);
            //    var position = positiontsToSpawnEnemies[index];
            //    positiontsToSpawnEnemies.Remove(position);
            //    _gameModel.EnemyCollection.CreateEnemy(EnemyType.EnemyPatrolling, position);
            //}
            _gameModel.EnemyCollection.CreateEnemy(EnemyType.EnemyOne, GetFreePosition());
            _gameModel.EnemyCollection.CreateEnemy(EnemyType.EnemyTwo, GetFreePosition());
            _gameModel.EnemyCollection.CreateEnemy(EnemyType.EnemyOne, GetFreePosition());
        }

        private Vector3 GetFreePosition()
        {
            var positiontsToSpawnEnemies = _gameModel.EnemyCollection.PositiontsToSpawnEnemies;
            var index = Random.Range(0, positiontsToSpawnEnemies.Count);
            var position = positiontsToSpawnEnemies[index];
            positiontsToSpawnEnemies.Remove(position);
            return position;
        }
    }
}