using Assets.Scripts.Models;
using Assets.Scripts.Views;
using Assets.Scripts.Enums;
using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts.Presenters
{
    public class CreatingEnemyPresenter : IPresenter
    {
        private GameModel _gameModel;
        private GameView _gameView;
        private Dictionary<Enemy, List<IPresenter>> _enemiesPresenters;

        public CreatingEnemyPresenter(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
            _enemiesPresenters = new Dictionary<Enemy, List<IPresenter>>();
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
                    enemy.points = _gameModel.SpawnPointsCollection.SpawnPointsAndPatrolling[enemy.InitialPosition];

                    List<IPresenter> presenters = new()
                    {
                        new EnemyAttackPresenter(enemy, enemyView, _gameView)
                    };
                    _enemiesPresenters.Add(enemy, presenters);

                    foreach(var presenter in presenters)
                    {
                        presenter.Subscribe();
                    }

                    break;
                }
            }
        }

        private void OnRemoved(Enemy enemy)
        {
            _gameModel.SpawnPointsCollection.ReturnFreeposition(enemy.InitialPosition);
            _gameView.ActiveEnemy[enemy.Id].Destroy();
            _gameView.ActiveEnemy.Remove(enemy.Id);

            if(!_enemiesPresenters.ContainsKey(enemy))
            {
                return;
            }

            foreach(var presenter in _enemiesPresenters[enemy])
            {
                presenter.Unsubscribe();
            }

            _enemiesPresenters.Remove(enemy);
        }
    }
}