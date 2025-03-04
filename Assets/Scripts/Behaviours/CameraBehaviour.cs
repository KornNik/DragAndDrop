using Data;
using DG.Tweening;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    sealed class CameraBehaviour : MonoBehaviour, IMovable
    {
        private Camera _camera;
        private CameraData _cameraData;
        private float _leftLimit;
        private float _rightLimit;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
            _cameraData = Services.Instance.DatasBundle.ServicesObject.GetData<CameraData>();
        }
        private void OnEnable()
        {
            Services.Instance.Level.ObjectIsLoaded += SetLimits;
        }
        private void OnDisable()
        {
            Services.Instance.Level.ObjectIsLoaded -= SetLimits;
        }

        public void Move(Vector3 movement)
        {
            var cameraPosition = _camera.transform.position;
            var finalCameraMovement = cameraPosition.x + movement.x;
            var clampPosition = Mathf.Clamp(finalCameraMovement, _leftLimit, _rightLimit);
            transform.DOMoveX(clampPosition + movement.x, _cameraData.CameraMoveDuration).SetEase(Ease.Linear);
        }

        private void SetLimits()
        {
            _leftLimit = Services.Instance.Level.ServicesObject.LeftLimit.position.x + (_camera.orthographicSize * 2);
            _rightLimit = Services.Instance.Level.ServicesObject.RightLimit.position.x - (_camera.orthographicSize * 2);
            Debug.Log($"Left = {_leftLimit} Right = {_rightLimit}");
        }
    }
}
