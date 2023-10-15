using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Views
{
    public class CameraView : MonoBehaviour
    {
        public Transform Transform;
        public Vector2 WindowSize; 
        public float SmoothSpeed = 20;
        [HideInInspector] public bool IsMove;
    }
}