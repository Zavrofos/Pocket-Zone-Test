using Assets.Scripts.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Presenters
{
    public class InitializePresenter : IPresenter
    {
        private GameModel _gameModel;
        private GameView _gameView;

        public InitializePresenter(GameModel gameModel, GameView gameView
            )
        {
            _gameModel = gameModel;
            _gameView = gameView;
        }

        public void Subscribe()
        {
            _gameModel.Initialized += OnInitializeSpawnPointsCollection;
            _gameModel.Initialized += OnInitializeEnemy;
        }

        public void Unsubscribe()
        {
            _gameModel.Initialized -= OnInitializeSpawnPointsCollection;
            _gameModel.Initialized -= OnInitializeEnemy;
        }

        private void OnInitializeSpawnPointsCollection()
        {
            foreach(var point in _gameView.PositionsToSpawnEnemies)
            {
                Vector3 spawnPosition = point.position;
                List<Vector3> patrollingPoints = new List<Vector3>();

                for(int i = 0; i < point.childCount; i++)
                {
                    patrollingPoints.Add(point.GetChild(i).position);
                }

                _gameModel.SpawnPointsCollection.SpawnPointsAndPatrolling.Add(spawnPosition, patrollingPoints);
            }
            _gameModel.SpawnPointsCollection.SetKeys();
        }

        private void OnInitializeEnemy()
        {
            for(int i = 0; i < 3; i++)
            {
                Vector3 position = _gameModel.SpawnPointsCollection.GetFreePosition();
                _gameModel.EnemyCollection.CreateEnemy(EnemyType.Enemy, position);
            }
        }
    }
}