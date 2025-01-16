using Helpers;
using Controllers;
using UnityEngine;
using Data;

namespace Behaviours
{
    class AudioInitializer : IInitialization
    {
        public void Initialization()
        {
            var audioControllerPrefab = Services.Instance.DatasBundle.ServicesObject.
                GetData<DataResourcePrefabs>().GetScreenPrefab(ScreenTypes.Canvas);
            var audioController = GameObject.Instantiate(audioControllerPrefab).GetComponent<AudioController>();

            Services.Instance.AudioPlayer.SetObject(audioController);
        }
    }
}
