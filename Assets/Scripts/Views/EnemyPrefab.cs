using Assets.Scripts.Enums;
using System;
using UnityEngine;



namespace Assets.Scripts.Views
{
    [Serializable]
    public class EnemyPrefab
    {
        public EnemyType Type;
        public GameObject Prefab;
    }
}
