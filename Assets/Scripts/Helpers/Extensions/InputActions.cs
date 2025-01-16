using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace Helpers.Extensions
{
    sealed class InputActions
    {
        private Dictionary<string, InputAction> _playerActionList = new Dictionary<string, InputAction>();

        public Dictionary<string, InputAction> PlayerActionList => _playerActionList;

        public InputActions(InputActionMap playerActionMap)
        {
            InitializeActions(playerActionMap);
        }

        private void InitializeActions(InputActionMap playerActionMap)
        {
            _playerActionList.Add(InputActionManagerPlayer.FIRE, playerActionMap.FindAction(InputActionManagerPlayer.FIRE));
            _playerActionList.Add(InputActionManagerPlayer.MOVEMENT, playerActionMap.FindAction(InputActionManagerPlayer.MOVEMENT));
            _playerActionList.Add(InputActionManagerPlayer.AIM, playerActionMap.FindAction(InputActionManagerPlayer.AIM));
            _playerActionList.Add(InputActionManagerPlayer.JUMP, playerActionMap.FindAction(InputActionManagerPlayer.JUMP));
            _playerActionList.Add(InputActionManagerPlayer.LOOK, playerActionMap.FindAction(InputActionManagerPlayer.LOOK));
            _playerActionList.Add(InputActionManagerPlayer.INTERACT, playerActionMap.FindAction(InputActionManagerPlayer.INTERACT));
            _playerActionList.Add(InputActionManagerPlayer.RELOAD, playerActionMap.FindAction(InputActionManagerPlayer.RELOAD));
            _playerActionList.Add(InputActionManagerPlayer.HOLSTER, playerActionMap.FindAction(InputActionManagerPlayer.HOLSTER));
            _playerActionList.Add(InputActionManagerPlayer.RUN, playerActionMap.FindAction(InputActionManagerPlayer.RUN));
        }
    }
}
