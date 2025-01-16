using Behaviours;
using Helpers;
using UnityEngine;

namespace Inputs
{
    abstract class BaseInputs : IInitialization
    {
        private Camera _camera;

        protected RaycastHit2D _hit2D;
        protected MovableObject _movableObject;

        public Camera Camera => _camera;

        public BaseInputs()
        {
            Initialization();
        }
        public void Update()
        {
            UpdateControll();
        }

        public virtual void Initialization()
        {
            _camera = Services.Instance.CameraService.ServicesObject;
        }

        public abstract void UpdateControll();

        protected void SetMovable()
        {
            var ray = GetScreenInputRay();
            _hit2D = Physics2D.Raycast(ray.origin, ray.direction, 20f, LayerMask.GetMask("Movable"));
            if (_hit2D)
            {
                _movableObject = _hit2D.transform.GetComponent<MovableObject>();
                _movableObject.OnBeginPointerDrag();
            }
        }
        protected void SetPosition()
        {
            var mousePos = GetScreenInputPosition();
            var movablePos = new Vector3(mousePos.x, mousePos.y);
            _movableObject.OnPointerDrag(movablePos);
        }
        protected void MovableRelease()
        {
            _movableObject.OnEndPointerDrag();
            _movableObject = null;
        }

        protected abstract Ray GetScreenInputRay();
        protected abstract Vector2 GetScreenInputPosition();
    }
}
