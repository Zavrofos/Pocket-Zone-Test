using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class Enemy 
    {
        public readonly string Type;
        public readonly int Id;
        public Vector3 InitialPosition;

        public Enemy(int id, Vector3 initialPosition, string type)
        {
            Id = id;
            InitialPosition = initialPosition;
            Type = type;
        }
    }
}