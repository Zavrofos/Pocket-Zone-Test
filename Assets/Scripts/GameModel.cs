using Assets.Scripts.Models;
using System;

namespace Assets.Scripts
{
    public class GameModel 
    {
        public readonly InputModel Input;
        public readonly PlayerModel Player;
        public readonly EnemyCollection EnemyCollection;
        public readonly SpawnPointsCollection SpawnPointsCollection;

        public event Action Initialized;
        
        public GameModel()
        {
            Input = new InputModel();
            Player = new PlayerModel();
            EnemyCollection = new EnemyCollection();
            SpawnPointsCollection = new SpawnPointsCollection();
        }

        public void Initialize()
        {
            Initialized?.Invoke();
        }
    }
}