using DG.Tweening;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(SpriteRenderer))]
    sealed class MovableObject : MonoBehaviour, IMovable, IItem
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Color _dragColor;

        private Color _defaultColor;
        private bool _dragging;
        private IShelf _currentShelf;

        public bool IsOnShelf => _currentShelf == null ? false : true;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _defaultColor = _spriteRenderer.color;
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (_dragging) { return; }
            if (IsOnShelf) { return; }

            if (collision.gameObject.layer == LayerMask.NameToLayer("Shelf"))
            {
                var shelf = collision.GetComponent<IShelf>();
                if (shelf != null)
                {
                    shelf.PutObjectOnShelf(this);
                }
            }

        }
        public void PutOnShelf(ShelfSpace shelfSpace, IShelf currentShelf)
        {
            _currentShelf = currentShelf;
            _rigidbody.isKinematic = true;
            _rigidbody.velocity = Vector3.zero;
            _collider.isTrigger = true;

            _spriteRenderer.sortingOrder = shelfSpace.ItemRenderOrder;
            transform.position = shelfSpace.ItemTransform.position;
        }
        public void RemoveFromShelf()
        {
            transform.parent = Services.Instance.Level.ServicesObject.transform;
            _spriteRenderer.sortingOrder = 0;
            _collider.isTrigger = false;
            _currentShelf = null;
        }
        public void Move(Vector3 movement)
        {
            _rigidbody.MovePosition(movement);
            transform.DOMove(movement, 0.2f);
        }

        public void OnBeginPointerDrag()
        {
            if (IsOnShelf)
            {
                _currentShelf.RemoveFromShelf(this);
            }
            _spriteRenderer.color = _dragColor;
            _rigidbody.isKinematic = true;
            _rigidbody.velocity = Vector3.zero;
            _dragging = true;
        }

        public void OnPointerDrag(Vector3 position)
        {
            Move(position);
        }

        public void OnEndPointerDrag()
        {
            SetDefaultValues();
        }

        private void SetDefaultValues()
        {
            _spriteRenderer.color = _defaultColor;
            _rigidbody.isKinematic = false;
            transform.DOKill();
            _dragging = false;
        }
    }
}
