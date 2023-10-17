using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class CreatingEnemyPresenter : IPresenter
    {
        private GameModel _gameModel;
        private GameView _gameView;

        public CreatingEnemyPresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }

        public void Subscribe()
        {
            _gameModel.EnemyCollection.CreatedEnemy += OnCreate;
        }

        public void Unsubscribe()
        {
            _gameModel.EnemyCollection.CreatedEnemy -= OnCreate;
        }

        private void OnCreate(Enemy enemy)
        {
            foreach(var enemyPrefab in _gameView.EnemyPrefabs)
            {
                if(enemyPrefab.Type == enemy.Type)
                {
                    GameObject enemyView = GameObject.Instantiate(enemyPrefab.Prefab, enemy.InitialPosition, Quaternion.identity);
                    EnemyView enemyV = enemyView.GetComponent<EnemyView>();
                    enemyV.Id = enemy.Id;
                    _gameView.ActiveEnemy.Add(enemyV.Id, enemyV);
                    break;
                }
            }
        }
    }
}