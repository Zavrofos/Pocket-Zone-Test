using Assets.Scripts.Models;
using Assets.Scripts.Views;
using UnityEngine;

namespace Assets.Scripts.Presenters
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
            _gameModel.EnemyCollection.Removed += OnRemoved;
        }

        public void Unsubscribe()
        {
            _gameModel.EnemyCollection.CreatedEnemy -= OnCreate;
            _gameModel.EnemyCollection.Removed -= OnRemoved;
        }

        private void OnCreate(IEnemy enemy)
        {
            foreach(var enemyPrefab in _gameView.EnemyPrefabs)
            {
                if(enemyPrefab.Type == enemy.Type)
                {
                    GameObject enemyView = GameObject.Instantiate(enemyPrefab.Prefab, enemy.InitialPosition, Quaternion.identity);
                    IEnemyView enemyV = enemyView.GetComponent<IEnemyView>();
                    enemyV.Id = enemy.Id;
                    _gameView.ActiveEnemy.Add(enemyV.Id, enemyV);




                    break;
                }
            }
        }

        private void OnRemoved(IEnemy enemy)
        {
            _gameView.ActiveEnemy[enemy.Id].Destroy();
            _gameView.ActiveEnemy.Remove(enemy.Id);
        }
    }
}