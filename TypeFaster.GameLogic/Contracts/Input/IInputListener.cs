using System;

namespace TypeFaster.GameLogic.Contracts.Input
{
    public interface IInputListener
    {
        ConsoleKeyInfo Listen();
        void SetInputHandler(IInputHandler inputHandler);
    }
}
