using UnityEngine;

namespace Assets.Scripts.Views
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        private int _id;

        public Rigidbody2D Rigidbody => _rigidbody;
        public Transform Transform => transform;
        public int Id { get => _id; set => _id = value; }
        
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}