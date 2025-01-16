using Helpers;
using System.Threading.Tasks;
using System;

namespace Behaviours
{
    sealed class LoadLevelState : BaseState
    {
        private ILevelLoader _levelLoader;

        public LoadLevelState(GameStateController stateController) : base(stateController)
        {
            _levelLoader = Services.Instance.LevelLoader.ServicesObject;
        }

        public override void EnterState()
        {
            base.EnterState();
            LoadAll();
        }
        private async void LoadAll()
        {
            await LoadTask(LoadLevelBehaviours);
            await LoadTask(StartGameState);
        }

        private async Task LoadTask(Action loadingAction)
        {
            loadingAction?.Invoke();
            await Task.Yield();
        }
        private void LoadLevelBehaviours()
        {
            _levelLoader.LoadLevelByIndex(0);
        }
        private void StartGameState()
        {
            ChangeGameStateEvent.Trigger(GameStateType.GameState);
        }
    }
}
