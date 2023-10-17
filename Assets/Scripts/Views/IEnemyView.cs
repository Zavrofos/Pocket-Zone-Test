using UnityEngine;

namespace Assets.Scripts.Views
{
    public interface IEnemyView
    {
        public Transform Transform { get; }
        public Rigidbody2D Rigidbody { get; } 
        public int Id { get; set; }
        void Destroy();
    }
}