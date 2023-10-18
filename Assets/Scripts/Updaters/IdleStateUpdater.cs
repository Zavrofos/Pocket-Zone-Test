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

                EnemyView enemyOneView = _gameView.ActiveEnemy[enemy.Value.Id];
                if (Vector3.Distance(enemyOneView.transform.position, enemy.Value.points[enemy.Value.currentPoint]) > 0.3f)
                {
                    enemy.Value.currentDirection = (enemy.Value.points[enemy.Value.currentPoint] - enemyOneView.transform.position).normalized;
                    enemyOneView.Rigidbody.velocity = enemy.Value.currentDirection * enemy.Value.Speed;
                }
                else if (enemy.Value.currentPoint == enemy.Value.points.Length - 1)
                {
                    enemy.Value.currentPoint = 0;
                }
                else
                {
                    enemy.Value.currentPoint++;
                }
            }
        }
    }
}