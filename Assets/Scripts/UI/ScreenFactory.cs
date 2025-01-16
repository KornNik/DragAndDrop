using UnityEngine;
using Helpers;
using Data;

namespace UI
{
    sealed class ScreenFactory
    {
        private Canvas _canvas;
        private GameMenu _gameMenu;
        private MainMenu _mainMenu;
        private PauseMenu _pauseMenu;


        public ScreenFactory()
        {
            var resources = Services.Instance.DatasBundle.ServicesObject.
                GetData<DataResourcePrefabs>().GetScreenPrefab(ScreenTypes.Canvas);
            _canvas = Object.Instantiate(resources, Vector3.one, Quaternion.identity).GetComponent<Canvas>();
        }

        public GameMenu GetGameMenu()
        {
            if (_gameMenu == null)
            {
                var resources = Services.Instance.DatasBundle.ServicesObject.
                    GetData<DataResourcePrefabs>().GetScreenPrefab(ScreenTypes.GameMenu);
                _gameMenu = Object.Instantiate(resources, _canvas.transform.position,
                    Quaternion.identity, _canvas.transform).GetComponent<GameMenu>();
            }
            return _gameMenu;
        }

        public MainMenu GetMainMenu()
        {
            if (_mainMenu == null)
            {
                var resources = Services.Instance.DatasBundle.ServicesObject.
                    GetData<DataResourcePrefabs>().GetScreenPrefab(ScreenTypes.MainMenu);
                _mainMenu = Object.Instantiate(resources, _canvas.transform.position,
                    Quaternion.identity, _canvas.transform).GetComponent<MainMenu>();
            }
            return _mainMenu;
        }
        public PauseMenu GetPauseMenu()
        {
            if (_pauseMenu == null)
            {
                var resources = Services.Instance.DatasBundle.ServicesObject.
                    GetData<DataResourcePrefabs>().GetScreenPrefab(ScreenTypes.PauseMenu);
                _pauseMenu = Object.Instantiate(resources, _canvas.transform.position,
                    Quaternion.identity, _canvas.transform).GetComponent<PauseMenu>();
            }
            return _pauseMenu;
        }
    }
}