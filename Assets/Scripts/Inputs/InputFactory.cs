using Inputs;
using UnityEngine;

namespace Behaviours
{
    sealed class InputFactory
    {
        public BaseInputs GetInputs()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                return new TouchScreenInput();
            }
            else
            {
                return new MouseInput();
            }
        }
    }
}
