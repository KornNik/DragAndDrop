using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName ="CameraData",menuName ="Data/Cameras/CameraData")]
    public class CameraData : ScriptableObject
    {
        [SerializeField] private float _cameraMoveDuration;
        [SerializeField] private float _cameraDistance;
        [SerializeField] private float _cameraRotationSpeed;
        [SerializeField] private Vector3 _mainCameraDefaultPosition;
        [SerializeField] private float _ortographicSize;

        public float CameraMoveDuration => _cameraMoveDuration;
        public float CameraDistance => _cameraDistance;
        public float OrtographicSize => _ortographicSize;
        public float CameraRotationSpeed => _cameraRotationSpeed;
        public Vector3 MainCameraDefaultPosition => _mainCameraDefaultPosition;
    }
}