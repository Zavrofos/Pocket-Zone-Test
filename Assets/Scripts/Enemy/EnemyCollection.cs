using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyCollection 
    {
        public List<Vector3> PositiontsToSpawnEnemies;
        public Dictionary<int, Enemy> ActiveEnemy;
        public event Action<Enemy> CreatedEnemy;
        private int id;

        public EnemyCollection()
        {
            PositiontsToSpawnEnemies = new List<Vector3>();
            ActiveEnemy = new Dictionary<int, Enemy>();
        }

        public void CreateEnemy(string type, Vector3 position)
        {
            var enemy = new Enemy(id, position, type);
            ActiveEnemy.Add(id, enemy);
            id++;
            CreatedEnemy?.Invoke(enemy);
        }
    }
}