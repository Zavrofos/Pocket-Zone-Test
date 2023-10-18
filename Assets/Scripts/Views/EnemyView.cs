using UnityEngine;

namespace Assets.Scripts.Views
{
    public class EnemyView : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Animator _animator;
        [SerializeField] private SpriteRenderer[] _spriteRendererPartsOfBody;
        private int _id;

        public Rigidbody2D Rigidbody => _rigidbody;
        public Transform Transform => transform;
        public int Id { get => _id; set => _id = value; }
        public Animator Animator { get => _animator; set => _animator = value; }
        public SpriteRenderer[] SpriteRendererPartsOfBody => _spriteRendererPartsOfBody; 

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}