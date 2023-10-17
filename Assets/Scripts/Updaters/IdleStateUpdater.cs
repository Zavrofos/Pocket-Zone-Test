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

        //public void Update(float deltaTime)
        //{
        //    foreach(var enemy in _gameModel.EnemyCollection.ActiveEnemy)
        //    {
        //        if(enemy.Value.CurrentState != EnemyState.Patrolling)
        //        {
        //            continue;
        //        }

        //        EnemyTwoView enemyPat = (EnemyTwoView)_gameView.ActiveEnemy[enemy.Value.Id];
        //        if (Vector3.Distance(enemyPat.transform.position, enemyPat.points[enemyPat.currentPoint]) > 0.3f)
        //        {
        //            enemyPat.currentDirection = (enemyPat.points[enemyPat.currentPoint] - enemyPat.transform.position).normalized;
        //            enemyPat.Rigidbody.velocity = enemyPat.currentDirection * enemy.Value.Speed;
        //        }
        //        else if (enemyPat.currentPoint == enemyPat.points.Length - 1)
        //        {
        //            enemyPat.currentPoint = 0;
        //        }
        //        else
        //        {
        //            enemyPat.currentPoint++;
        //        }
        //    }
        //}


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

                }

                if(enemy.Value is EnemyTwo)
                {
                    EnemyTwoView enemyView = (EnemyTwoView)_gameView.ActiveEnemy[enemy.Value.Id];
                    if (Vector3.Distance(enemyView.transform.position, enemyView.points[enemyView.currentPoint]) > 0.3f)
                    {
                        enemyView.currentDirection = (enemyView.points[enemyView.currentPoint] - enemyView.transform.position).normalized;
                        enemyView.Rigidbody.velocity = enemyView.currentDirection * enemy.Value.Speed;
                    }
                    else if (enemyView.currentPoint == enemyView.points.Length - 1)
                    {
                        enemyView.currentPoint = 0;
                    }
                    else
                    {
                        enemyView.currentPoint++;
                    }
                }
            }
        }
    }
}