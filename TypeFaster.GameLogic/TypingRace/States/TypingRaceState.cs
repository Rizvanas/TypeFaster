using System;
using TypeFaster.GameLogic.Contracts.Input;
using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.UI.Contracts;

namespace TypeFaster.GameLogic.TypingRace.States
{
    public abstract class TypingRaceState
    {
        protected IInputHandler _inputHandler;
        protected IGameRenderer _gameRenderer;

        public void SetInputHandler(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        public void SetRenderer(IGameRenderer gameRenderer)
        {
            _gameRenderer = gameRenderer;
        }

        public abstract void HandleInput(ConsoleKeyInfo keyInfo);
        public abstract void Render(ITypingRaceInstance typingRaceInstance);
    }
}
