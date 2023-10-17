using Assets.Scripts.Enums;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public interface IEnemy 
    {
        public EnemyState CurrentState { get; set; }
        public EnemyType Type { get; }
        public int Id { get; }
        public Vector3 InitialPosition { get; }
        public float Speed { get; set; }
        public float RadiusFinderPlayer { get; }
        public Transform TargetPlayer { get; set; }

        void ChangeState(EnemyState newState);
    }
}