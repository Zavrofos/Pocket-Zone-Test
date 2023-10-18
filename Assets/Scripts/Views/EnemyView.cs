using UnityEngine;

namespace Assets.Scripts.Views
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform[] _patrollPoints;
        private int _id;

        public Rigidbody2D Rigidbody => _rigidbody;
        public Transform Transform => transform;
        public Transform[] PatrollPoints => _patrollPoints;
        public int Id { get => _id; set => _id = value; }
        
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}