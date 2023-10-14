using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

namespace Assets.Scripts.Views
{
    public class JostickView : MonoBehaviour
    {
        public RectTransform RectTransform;
        public RectTransform Knob;
        public Finger MovementFinger;
        public Vector2 JoystickSize;
    }
}