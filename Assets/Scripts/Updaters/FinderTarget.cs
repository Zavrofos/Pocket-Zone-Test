using Assets.Scripts.Enums;
using Assets.Scripts.Views;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Updaters
{
    public class FinderTarget : IUpdater
    {
        private GameModel _gameModel;
        private GameView _gameView;

        public FinderTarget(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }

        public void Update(float deltaTime)
        {
            foreach(var enemy in _gameModel.EnemyCollection.ActiveEnemy)
            {
                if(enemy.Value.CurrentState != EnemyState.Attack)
                {
                    IEnemyView enemyView = _gameView.ActiveEnemy[enemy.Value.Id];

                    Collider2D playerTarget = Physics2D.OverlapCircle(enemyView.Transform.position,
                        enemy.Value.RadiusFinderPlayer, LayerMask.GetMask("Player"));

                    if (playerTarget != null)
                    {
                        enemy.Value.TargetPlayer = playerTarget.transform;
                        enemy.Value.ChangeState(EnemyState.Attack);
                    }
                }
            }
        }
    }
}