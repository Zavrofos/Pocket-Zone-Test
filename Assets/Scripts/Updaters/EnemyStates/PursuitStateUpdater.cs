using Assets.Scripts.Enums;
using Assets.Scripts.Models;
using Assets.Scripts.Views;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Updaters
{
    public class PursuitStateUpdater : IUpdater
    {
        private GameModel _gameModel;
        private GameView _gameView;

        public PursuitStateUpdater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }

        public void Update(float deltaTime)
        {
            foreach(var activeEnemy in _gameModel.EnemyCollection.ActiveEnemy)
            {
                Enemy enemy = activeEnemy.Value;
                EnemyView enemyView = _gameView.ActiveEnemy[enemy.Id];

                if(enemy.CurrentState != EnemyState.Persuit)
                {
                    continue;
                }

                float distance = Vector2.Distance(enemy.TargetPersuit.position, enemy.CurrentPosition);

                if (distance <= enemy.SearchRadiusForAttack)
                {
                    enemy.ChangeState(EnemyState.Attack);
                    return;
                }

                if(distance > enemy.SearchRadiusForPersuit)
                {
                    enemy.TargetPersuit = null;
                    enemy.ChangeState(EnemyState.Idle);
                    return;
                }

                Vector3 direction = enemy.TargetPersuit.position - enemy.CurrentPosition;
                enemyView.Rigidbody.velocity = direction * enemy.Speed;
                enemy.CurrentPosition = enemyView.transform.position;
            }
        }
    }
}