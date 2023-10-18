using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Models
{
    public class SpawnPointsCollection
    {
        public Dictionary<Vector3, List<Vector3>> SpawnPointsAndPatrolling;
        private List<Vector3> _keys;

        public SpawnPointsCollection()
        {
            SpawnPointsAndPatrolling = new ();
            _keys = new();
        }

        public Vector3 GetFreePosition()
        {
            int index = Random.Range(0, _keys.Count);
            Vector3 key = _keys[index];
            _keys.Remove(key);
            return key;
        }

        public void SetKeys()
        {
            foreach(var point in SpawnPointsAndPatrolling)
            {
                _keys.Add(point.Key);
            }
        }

        public void ReturnFreeposition(Vector3 position)
        {
            _keys.Add(position);
        }
    }
}