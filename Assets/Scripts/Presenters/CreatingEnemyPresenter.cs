using Assets.Scripts.Models;
using Assets.Scripts.Views;
using Assets.Scripts.Enums;
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

        private void OnCreate(Enemy enemy)
        {
            foreach(var enemyPrefab in _gameView.EnemyPrefabs)
            {
                if(enemyPrefab.Type == enemy.Type)
                {
                    GameObject enemyObj = Object.Instantiate(enemyPrefab.Prefab, enemy.InitialPosition, Quaternion.identity);
                    EnemyView enemyView = enemyObj.GetComponent<EnemyView>();
                    enemyView.Id = enemy.Id;
                    _gameView.ActiveEnemy.Add(enemyView.Id, enemyView);

                    if(enemyPrefab.Type == EnemyType.Enemy)
                    {
                        enemy.points = new Vector3[enemyView.PatrollPoints.Length];
                        for(int i = 0; i < enemy.points.Length; i++)
                        {
                            enemy.points[i] = enemyView.PatrollPoints[i].position;
                        }
                    }
                    break;
                }
            }
        }

        private void OnRemoved(Enemy enemy)
        {
            _gameView.ActiveEnemy[enemy.Id].Destroy();
            _gameView.ActiveEnemy.Remove(enemy.Id);
        }
    }
}