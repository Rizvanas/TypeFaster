using System;
using TypeFaster.GameLogic.Contracts.Input;

namespace TypeFaster.GameLogic.Input.Listeners
{
    public class InputListener : IInputListener
    {
        private IInputHandler _inputHandler;

        public void SetInputHandler(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        public ConsoleKeyInfo Listen()
        {
            var keypress = Console.ReadKey(true);
            return keypress;
        }
    }
}
