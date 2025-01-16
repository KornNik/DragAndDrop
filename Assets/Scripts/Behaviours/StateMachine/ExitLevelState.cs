using Helpers;
using System.Threading.Tasks;
using System;

namespace Behaviours
{
    sealed class ExitLevelState : BaseState
    {
        private ILevelLoader _levelLoader;
        public ExitLevelState(GameStateController stateController) : base(stateController)
        {
            _levelLoader = Services.Instance.LevelLoader.ServicesObject;
        }
        public override void EnterState()
        {
            base.EnterState();
            DeleteAll();
        }

        private async void DeleteAll()
        {
            await LoadTask(DeleteLevel);
        }
        private async Task LoadTask(Action loadingAction)
        {
            loadingAction?.Invoke();
            await Task.Yield();
        }
        private void DeleteLevel()
        {
            _levelLoader.ClearLevelFull();
        }
        private void StartGameState()
        {
            ChangeGameStateEvent.Trigger(GameStateType.MenuState);
        }
    }
}
