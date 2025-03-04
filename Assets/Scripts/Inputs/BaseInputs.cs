using Behaviours;
using Helpers;
using Helpers.Extensions;
using UnityEngine;

namespace Inputs
{
    abstract class BaseInputs : IInitialization
    {
        private Camera _camera;

        protected RaycastHit2D _hit2D;
        protected MovableObject _movableObject;
        protected InputActions _inputs;
        protected RaycastHit2D[] _hits2D;

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
            _inputs = Services.Instance.Inputs.ServicesObject;
            _hits2D = new RaycastHit2D[2];
        }

        public void UpdateControll()
        {
            if (IsInputTouch())
            {
                if (IsMovable() || ObjectIsDragging())
                {
                    if (_movableObject == null)
                    {
                        SetMovable();
                    }
                    else
                    {
                        SetPosition();
                    }
                }
                else
                {
                    MoveCamera();
                }
            }
            else
            {
                if (_movableObject != null)
                {
                    MovableRelease();
                }
            }
        }

        protected void MoveCamera()
        {
            var isMoving = _inputs.PlayerActionList
                [InputActionManagerPlayer.LOOK].IsPressed();
            if (isMoving)
            {
                var lookingMovement = _inputs.PlayerActionList
                    [InputActionManagerPlayer.LOOK].ReadValue<Vector2>();
                _camera.GetComponent<IMovable>().Move(lookingMovement);
            }
        }
        protected void SetMovable()
        {
            _movableObject = _hits2D[0].transform.GetComponent<MovableObject>();
            _movableObject.OnBeginPointerDrag();
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
        protected bool IsMovable()
        {
            var ray = GetScreenInputRay();
            var hits = Physics2D.RaycastNonAlloc(ray.origin, ray.direction, _hits2D, 20f, LayerMask.GetMask("Movable"));

            return hits > 0;
        }
        protected bool ObjectIsDragging()
        {
            return _movableObject != null;
        }

        protected abstract Ray GetScreenInputRay();
        protected abstract Vector2 GetScreenInputPosition();
        protected abstract bool IsInputTouch();
    }
}
