﻿using Assets.Scripts.Enums;
using Assets.Scripts.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

namespace Assets.Scripts.Models
{ 
    public class Enemy
    {
        public EnemyType Type => _type;
        public int Id => _id;
        public Vector3 InitialPosition => _initialPosition;
        public Vector3 CurrentPosition { get => _currentPosition; set => _currentPosition = value; }
        public EnemyState CurrentState { get => _currentState; set => _currentState = value; }
        public float Speed => _speed; 
        public Transform TargetPersuit { get => _targetPersuit; set => _targetPersuit = value; }
        public float SearchRadiusForPersuit => _searchRadiusForPersuit;
        public float SearchRadiusForAttack => _searchRadiusForAttack;

        private readonly EnemyType _type;
        private readonly int _id;
        private readonly Vector3 _initialPosition;
        private Vector3 _currentPosition;
        private EnemyState _currentState;
        private float _speed = 0.5f;
        private Transform _targetPersuit;
        private float _searchRadiusForPersuit = 4;
        private float _searchRadiusForAttack = 1f;

        // Patrolling
        public List<Vector3> points;
        public Vector3 currentDirection;
        public int currentPoint;

        // Attack
        public bool IsAttacking;
        public event Action<Transform> Attacked;
        public event Action<Vector3> DirectionAssigned;

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

        public void Attack(Transform target)
        {
            if(IsAttacking)
            {
                return;
            }
            Attacked?.Invoke(TargetPersuit);
        }

        public void SetDirection(Vector3 newDirection)
        {
            currentDirection = newDirection;
            DirectionAssigned?.Invoke(currentDirection);
        }
    }
}