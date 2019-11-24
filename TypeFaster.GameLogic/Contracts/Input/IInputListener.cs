using System;

namespace TypeFaster.GameLogic.Contracts.Input
{
    public interface IInputListener
    {
        ConsoleKeyInfo Listen();
    }
}
