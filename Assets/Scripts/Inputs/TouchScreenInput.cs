using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch;

namespace Inputs
{
    sealed class TouchScreenInput : BaseInputs
    {
        private Finger _touch;

        public override void Initialization()
        {
            base.Initialization();
            EnhancedTouchSupport.Enable();
        }

        public override void UpdateControll()
        {
            if (Touch.Touch.activeTouches.Count > 0)
            {
                Debug.Log("Touch");
                _touch = Touch.Touch.fingers.FirstOrDefault();

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
                if (_movableObject != null)
                {
                    MovableRelease();
                }
            }
        }

        protected override Vector2 GetScreenInputPosition()
        {
            var inputTouchPosition = _touch.currentTouch.screenPosition;
            var inputTouchPositionWithDepth = new Vector3(inputTouchPosition.x,
                inputTouchPosition.y, Mathf.Abs(Camera.transform.position.z));
            var position = Camera.ScreenToWorldPoint(inputTouchPositionWithDepth);
            return position;
        }

        protected override Ray GetScreenInputRay()
        {
            var inputTouchPosition = _touch.currentTouch.screenPosition;
            var ray = Camera.ScreenPointToRay(inputTouchPosition);
            return ray;
        }
    }
}
