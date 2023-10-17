using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public interface IEnemyView 
    {
        public int Id { get; set; }
        void Destroy();
    }
}