using Assets.Scripts.EnemyPatrollingRep;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyCollection 
    {
        public List<Vector3> PositiontsToSpawnEnemies;
        public Dictionary<int, IEnemy> ActiveEnemy;
        public event Action<IEnemy> CreatedEnemy;
        public event Action<IEnemy> Removed;
        private int id;


        public EnemyCollection()
        {
            PositiontsToSpawnEnemies = new List<Vector3>();
            ActiveEnemy = new Dictionary<int, IEnemy>();
        }

        public void CreateEnemy(EnemyType type, Vector3 position)
        {
            IEnemy enemy;

            switch(type)
            {
                case EnemyType.Enemy:
                    enemy = new Enemy(id, position, type);
                    break;
                case EnemyType.EnemyPatrolling :
                    enemy = new EnemyPatrolling(id, position, type); 
                    break;
                default:
                    enemy = null;
                    break;
            }

            if(enemy == null)
            {
                return;
            }

            ActiveEnemy.Add(id, enemy);
            id++;
            CreatedEnemy?.Invoke(enemy);
        }

        public void Remove(IEnemy enemy)
        {
            PositiontsToSpawnEnemies.Add(enemy.InitialPosition);
            ActiveEnemy.Remove(enemy.Id);
            Removed?.Invoke(enemy);
        }
    }
}