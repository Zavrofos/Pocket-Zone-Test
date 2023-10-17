using UnityEngine;

namespace Assets.Scripts.Views
{
    public class EnemyTwoView : MonoBehaviour, IEnemyView
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        private int _id;

        public Rigidbody2D Rigidbody => _rigidbody;
        public Transform Transform => transform;
        int IEnemyView.Id { get => _id; set => _id = value; }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}