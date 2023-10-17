using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

namespace Assets.Scripts.Input
{
    public class JostickView : MonoBehaviour
    {
        public RectTransform RectTransform;
        public RectTransform Knob;
        public Finger MovementFinger;
        public Vector2 JoystickSize = new Vector2(100, 100);
    }
}