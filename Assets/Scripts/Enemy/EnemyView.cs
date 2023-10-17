using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyView : MonoBehaviour, IEnemyView
    {
        int IEnemyView.Id { get => _id; set => _id = value; }
        private int _id;

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}