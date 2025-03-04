using UnityEngine;
using Data;
using Helpers;

namespace Behaviours
{
   sealed class CamerasInitializer : IInitialization
    {
        private CameraData _cameraData;

        public void Initialization()
        {
            CamerasDataInitialization();
            MainCameraInitialization();
        }

        private void CamerasDataInitialization()
        {
            var dataResources = Services.Instance.DatasBundle.ServicesObject.GetData<CameraData>();
            _cameraData = dataResources;
        }
        private void MainCameraInitialization()
        {
            var mainCameraResource = Services.Instance.DatasBundle.ServicesObject.GetData<DataResourcePrefabs>().GetCamerPrefab();
            var mainCameraObject = Object.Instantiate(mainCameraResource, _cameraData.MainCameraDefaultPosition, Quaternion.identity).GetComponent<Camera>();
            mainCameraObject.stereoTargetEye = StereoTargetEyeMask.None;
            mainCameraObject.orthographicSize = _cameraData.OrtographicSize;

            Services.Instance.CameraService.SetObject(mainCameraObject);
        }
    }
}
