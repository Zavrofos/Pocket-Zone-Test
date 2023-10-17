using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public interface IEnemy 
    {
        public EnemyType Type { get; }
        public int Id { get; }
        public Vector3 InitialPosition { get; }
    }
}