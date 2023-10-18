using Assets.Scripts.Models;
using Assets.Scripts.Enums;
using System.Collections;
using UnityEngine;
using Assets.Scripts.Views;

namespace Assets.Scripts.Updaters
{
    public class AttackStateUpdater : IUpdater
    {
        private GameModel _gameModel;
        private GameView _gameView;

        public AttackStateUpdater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }

        public void Update(float deltaTime)
        {
            foreach(var activeEnemy in _gameModel.EnemyCollection.ActiveEnemy)
            {
                if(activeEnemy.Value.CurrentState != EnemyState.Attack)
                {
                    continue;
                }

                Enemy enemy = activeEnemy.Value;
                EnemyView enemyView = _gameView.ActiveEnemy[enemy.Id];

                float distance = Vector2.Distance(enemy.CurrentPosition, enemy.TargetPersuit.position);

                if(distance > enemy.SearchRadiusForAttack)
                {
                    enemy.ChangeState(EnemyState.Persuit);
                    return;
                }

                enemyView.Rigidbody.velocity = Vector2.zero;
                enemy.CurrentPosition = enemyView.Transform.position;
                enemy.Attack(enemy.TargetPersuit);
            }
        }
    }
}