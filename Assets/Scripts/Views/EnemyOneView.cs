using UnityEngine;

namespace Assets.Scripts.Views
{
    public class EnemyOneView : MonoBehaviour, IEnemyView
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Transform[] _patrollPoints;
        private int _id;

        public Rigidbody2D Rigidbody => _rigidbody;
        public Transform Transform => transform;
        public Transform[] PatrollPoints => _patrollPoints;
        int IEnemyView.Id { get => _id; set => _id = value; }
        
        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}