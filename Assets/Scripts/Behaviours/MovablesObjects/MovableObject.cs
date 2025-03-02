﻿using DG.Tweening;
using Helpers;
using Helpers.Managers;
using UnityEngine;

namespace Behaviours
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(SpriteRenderer))]
    sealed class MovableObject : MonoBehaviour, IMovable, IItem, IPointerDrag
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private Color _dragColor;

        private Color _defaultColor;
        private bool _dragging;
        private IShelf _currentShelf;

        private void Awake()
        {
            Initialize();
            SetDefaultValues();
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (_dragging) { return; }
            if (IsOnShelf) { return; }

            if (collision.gameObject.layer == LayersManager.ShelfLayer)
            {
                var shelf = collision.GetComponent<IShelf>();
                if (shelf != null)
                {
                    shelf.PutObjectOnShelf(this);
                }
            }

        }

        private void Initialize()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _defaultColor = _spriteRenderer.color;
        }
        private void SetDefaultValues()
        {
            _spriteRenderer.color = _defaultColor;
            _rigidbody.isKinematic = false;
            transform.DOKill();
            _dragging = false;
        }
        private void SetDraggingValues()
        {
            _spriteRenderer.color = _dragColor;
            _rigidbody.isKinematic = true;
            _rigidbody.velocity = Vector3.zero;
            _dragging = true;
        }


        #region IMovable

        public void Move(Vector3 movement)
        {
            transform.DOMove(movement, 0.2f);
        }

        #endregion


        #region IItem

        public bool IsOnShelf => _currentShelf == null ? false : true;

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

        #endregion


        #region IPointerDrag

        public void OnBeginPointerDrag()
        {
            if (IsOnShelf)
            {
                _currentShelf.RemoveFromShelf(this);
            }
            SetDraggingValues();
        }

        public void OnPointerDrag(Vector3 position)
        {
            Move(position);
        }

        public void OnEndPointerDrag()
        {
            SetDefaultValues();
        }

        #endregion
    }
}
