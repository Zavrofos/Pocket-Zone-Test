using Assets.Scripts.Enemy;
using UnityEngine;

namespace Assets.Scripts.EnemyPatrollingRep
{
    public class EnemyPatrolling : IEnemy
    {
        public EnemyType Type => _type;
        int IEnemy.Id => _id;
        Vector3 IEnemy.InitialPosition => _initialPosition;

        

        private readonly EnemyType _type;
        private readonly int _id;
        private readonly Vector3 _initialPosition;

        public Vector3 CurrentPosition;


        public EnemyPatrolling(int id, Vector3 initialPosition, EnemyType type)
        {
            _id = id;
            _initialPosition = initialPosition;
            _type = type;
        }
    }
}