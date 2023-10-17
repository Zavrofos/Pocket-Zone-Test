using Assets.Scripts.Enums;
using Assets.Scripts.Models;
using Assets.Scripts.Views;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Updaters
{
    public class IdleStateUpdater : IUpdater
    {
        private GameModel _gameModel;
        private GameView _gameView;

        public IdleStateUpdater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }
        
        public void Update(float deltaTime)
        {
            foreach (var enemy in _gameModel.EnemyCollection.ActiveEnemy)
            {
                if (enemy.Value.CurrentState != EnemyState.Idle)
                {
                    continue;
                }

                if(enemy.Value is EnemyOne)
                {
                    EnemyOneView enemyOneView = (EnemyOneView)_gameView.ActiveEnemy[enemy.Value.Id];
                    EnemyOne enemyOne = (EnemyOne)enemy.Value;
                    if (Vector3.Distance(enemyOneView.transform.position, enemyOne.points[enemyOne.currentPoint]) > 0.3f)
                    {
                        enemyOne.currentDirection = (enemyOne.points[enemyOne.currentPoint] - enemyOneView.transform.position).normalized;
                        enemyOneView.Rigidbody.velocity = enemyOne.currentDirection * enemyOne.Speed;
                    }
                    else if (enemyOne.currentPoint == enemyOne.points.Length - 1)
                    {
                        enemyOne.currentPoint = 0;
                    }
                    else
                    {
                        enemyOne.currentPoint++;
                    }
                }

                if (enemy.Value is EnemyTwo)
                {

                }
            }
        }
    }
}