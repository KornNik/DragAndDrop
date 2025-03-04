using Helpers;
using Inputs;
using UI;

namespace Behaviours
{
    sealed class GameState : BaseState
    {
        private BaseInputs _inputs;
        public GameState(GameStateController stateController) : base(stateController)
        {
            _inputs = new InputFactory().GetInputs();
        }

        public override void EnterState()
        {
            ScreenInterface.GetInstance().Execute(ScreenTypes.GameMenu);
        }

        public override void ExitState()
        {
        }

        public override void LogicFixedUpdate()
        {

        }

        public override void LogicUpdate()
        {
            _inputs.Update();
        }
    }
}
