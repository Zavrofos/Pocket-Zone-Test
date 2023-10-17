using Assets.Scripts.Enums;
using Assets.Scripts.Views;
using UnityEngine;

namespace Assets.Scripts.Updaters
{
    public class PersuitOfPlayerUpdater : IUpdater
    {
        private GameModel _gameModel;
        private GameView _gameView;

        public PersuitOfPlayerUpdater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }

        public void Update(float deltaTime)
        {
            foreach(var enemy in _gameModel.EnemyCollection.ActiveEnemy)
            {
                if (enemy.Value.CurrentState != EnemyState.Attack)
                {
                    continue;
                }

                IEnemyView enemyView = _gameView.ActiveEnemy[enemy.Value.Id];
                Vector3 direction = enemy.Value.TargetPlayer.position - enemyView.Transform.position;
                enemyView.Rigidbody.velocity = direction * enemy.Value.Speed;
            }
        }
    }
}