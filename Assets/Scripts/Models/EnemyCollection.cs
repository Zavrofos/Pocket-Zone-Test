using Assets.Scripts.Enums;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class EnemyCollection 
    {
        public Dictionary<int, Enemy> ActiveEnemy;

        public event Action<Enemy> CreatedEnemy;
        public event Action<Enemy> Removed;

        private int id;


        public EnemyCollection()
        {
            ActiveEnemy = new Dictionary<int, Enemy>();
        }

        public void CreateEnemy(EnemyType type, Vector3 position)
        {
            Enemy enemy;

            switch(type)
            {
                case EnemyType.Enemy:
                    enemy = new Enemy(id, position, type);
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

        public void Remove(Enemy enemy)
        {
            ActiveEnemy.Remove(enemy.Id);
            Removed?.Invoke(enemy);
        }
    }
}