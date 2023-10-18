using Assets.Scripts.Views;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameView : MonoBehaviour
    {
        public JostickView Joystick;
        public PlayerView PlayerView;
        public CameraView CameraView;

        public List<Transform> PositionsToSpawnEnemies;
        public List<EnemyPrefab> EnemyPrefabs;

        public Dictionary<int, EnemyView> ActiveEnemy;

        private void Start()
        {
            ActiveEnemy = new Dictionary<int, EnemyView>();
        }
    }
}
