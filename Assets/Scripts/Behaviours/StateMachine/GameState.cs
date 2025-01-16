using Helpers;
using Inputs;
using UI;
using UnityEngine;

namespace Behaviours
{
    sealed class GameState : BaseState
    {
        private BaseInputs _inputs;
        public GameState(GameStateController stateController) : base(stateController)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                _inputs = new TouchScreenInput();
            }
            else
            {
                _inputs = new MouseInput();
            }
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
