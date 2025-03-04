using UnityEngine;

namespace Behaviours
{
    sealed class Level : MonoBehaviour
    {
        [SerializeField] private Transform _leftLimit;
        [SerializeField] private Transform _rightLimit;

        public Transform LeftLimit => _leftLimit;
        public Transform RightLimit => _rightLimit;
    }
}
