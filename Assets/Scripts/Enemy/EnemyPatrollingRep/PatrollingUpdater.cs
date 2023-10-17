using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy.EnemyPatrollingRep
{
    public class PatrollingUpdater : IUpdater
    {
        private GameModel _gameModel;
        private GameView _gameView;

        public PatrollingUpdater(GameModel gameModel, GameView gameView)
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }

        public void Update(float deltaTime)
        {
            
        }
    }
}