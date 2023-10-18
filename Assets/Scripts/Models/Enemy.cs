using Assets.Scripts.Enums;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Models
{ 
    public class Enemy
    {
        public EnemyType Type => _type;
        public int Id => _id;
        public Vector3 InitialPosition => _initialPosition;
        public float RadiusFinderPlayer => _radiusFinderEnemy;
        public EnemyState CurrentState { get => _currentState; set => _currentState = value; }
        public float Speed { get => _speed; set => _speed = value; }
        public Transform TargetPlayer { get => _target; set => _target = value; }

        private readonly EnemyType _type;
        private readonly int _id;
        private readonly Vector3 _initialPosition;
        private float _radiusFinderEnemy = 3;
        private EnemyState _currentState;
        private float _speed = 0.5f;
        private Transform _target;
        public Vector3 CurrentPosition;

        public Vector3[] points;
        public Vector3 currentDirection;
        public int currentPoint;

        public Enemy(int id, Vector3 initialPosition, EnemyType type)
        {
            _id = id;
            _initialPosition = initialPosition;
            _type = type;
            CurrentState = EnemyState.Idle;
        }

        public void ChangeState(EnemyState newState)
        {
            CurrentState = newState;
        }
    }
}