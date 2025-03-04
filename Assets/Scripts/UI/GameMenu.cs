using UnityEngine;
using UnityEngine.UI;
using Behaviours;
using UnityEngine.InputSystem.OnScreen;

namespace UI
{
    class GameMenu : BaseUI
    {
        [SerializeField] private OnScreenStick _lookJoystick;

        private void OnEnable()
        {
        }
        private void OnDisable()
        {
        }
        public override void Show()
        {
            gameObject.SetActive(true);
            ShowUI.Invoke();
        }
        public override void Hide()
        {
            gameObject.SetActive(false);
            HideUI.Invoke();
        }
    }
}