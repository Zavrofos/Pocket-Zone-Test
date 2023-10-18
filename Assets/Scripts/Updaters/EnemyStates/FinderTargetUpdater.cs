using Assets.Scripts.Models;
using Assets.Scripts.Enums;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Updaters
{
    public class FinderTargetUpdater : IUpdater
    {
        private GameModel _gameModel;
        private GameView _gameView;
        private float searchRadiusForPersuit = 3;
        private float searchRadiusForAttack = 0.6f;

        public FinderTargetUpdater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }

        public void Update(float deltaTime)
        {
            //foreach(var activeEnemy in _gameModel.EnemyCollection.ActiveEnemy)
            //{
            //    Enemy enemy = activeEnemy.Value;

            //    Collider2D target = Physics2D.OverlapCircle(enemy.CurrentPosition, searchRadiusForPersuit, LayerMask.GetMask("Player"));
                
            //    if(target != null)
            //    {
            //        enemy.TargetPersuit = target.transform;
            //        enemy.ChangeState(EnemyState.Persuit);
            //    }
            //    else
            //    {
            //        enemy.TargetPersuit = null;
            //    }
            //}
        }
    }
}