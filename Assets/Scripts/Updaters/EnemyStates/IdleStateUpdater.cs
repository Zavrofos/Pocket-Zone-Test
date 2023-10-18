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
            foreach (var activeEnemy in _gameModel.EnemyCollection.ActiveEnemy)
            {
                if (activeEnemy.Value.CurrentState != EnemyState.Idle)
                {
                    continue;
                }

                Enemy enemy = activeEnemy.Value;

                Collider2D target = Physics2D.OverlapCircle(enemy.CurrentPosition, 
                    enemy.SearchRadiusForPersuit, LayerMask.GetMask("Player"));

                if(target != null)
                {
                    enemy.TargetPersuit = target.transform;
                    enemy.ChangeState(EnemyState.Persuit);
                    return;
                }

                EnemyView enemyOneView = _gameView.ActiveEnemy[enemy.Id];
                if (Vector3.Distance(enemyOneView.transform.position, enemy.points[enemy.currentPoint]) > 0.3f)
                {
                    enemy.currentDirection = (enemy.points[enemy.currentPoint] - enemyOneView.transform.position).normalized;
                    enemyOneView.Rigidbody.velocity = enemy.currentDirection * enemy.Speed;
                }
                else if (enemy.currentPoint == enemy.points.Count - 1)
                {
                    enemy.currentPoint = 0;
                }
                else
                {
                    enemy.currentPoint++;
                }

                enemy.CurrentPosition = enemyOneView.transform.position;
            }
        }
    }
}