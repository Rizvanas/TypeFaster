using System;
using TypeFaster.GameLogic.Contracts.Input;

namespace TypeFaster.GameLogic.Input.Listeners
{
    public class InputListener : IInputListener
    {
        public ConsoleKeyInfo Listen()
        {
            var keypress = Console.ReadKey(true);
            return keypress;
        }
    }
}
