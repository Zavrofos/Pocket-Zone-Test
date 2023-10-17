using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class Enemy : IEnemy
    {
        public EnemyType Type => _type;
        public int Id => _id;
        public Vector3 InitialPosition => _initialPosition;

        private EnemyType _type;
        private int _id;
        private Vector3 _initialPosition;

        public Enemy(int id, Vector3 initialPosition, EnemyType type)
        {
            _type = type;
            _id = id;
            _initialPosition = initialPosition;
        }
    }
}