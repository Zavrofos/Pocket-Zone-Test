using UnityEngine;

namespace Assets.Scripts.Views
{
    public class EnemyTwoView : MonoBehaviour, IEnemyView
    {
        public Rigidbody2D Rigidbody => _rigidbody;
        public Transform Transform => transform;
        int IEnemyView.Id { get => _id; set => _id = value; }
        public Transform[] PatrollPoints => _patrollPoints;

        [SerializeField] private Rigidbody2D _rigidbody;
        private int _id;
        [SerializeField] private Transform[] _patrollPoints;

        public Vector3[] points;
        public Vector3 currentDirection;
        public int currentPoint;

        private void Start()
        {
            points = new Vector3[PatrollPoints.Length];

            for(int i = 0; i < points.Length; i++)
            {
                points[i] = PatrollPoints[i].position;
            }
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}