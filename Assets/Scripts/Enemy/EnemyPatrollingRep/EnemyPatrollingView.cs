using Assets.Scripts.Enemy;
using UnityEngine;

namespace Assets.Scripts.EnemyPatrollingRep
{
    public class EnemyPatrollingView : MonoBehaviour, IEnemyView
    {
        public Transform[] PatrollPoints;
        int IEnemyView.Id { get => _id; set => _id = value; }
        private int _id;

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}