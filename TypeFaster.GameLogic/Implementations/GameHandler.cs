using System;
using System.Timers;
using TypeFaster.Domain.ValueObjects;
using TypeFaster.GameLogic.Contracts;
using TypeFaster.GameServices.Contracts;
using TypeFaster.UI.Contracts;

namespace TypeFaster.GameLogic.Implementations
{
    public abstract class GameHandler
    {
        protected ITypingRace _typingRace;
        protected readonly IInputListener _userInputListener;
        protected readonly IInputHandler _inputHandler;
        protected readonly IGameRenderer _gameRenderer;
        protected readonly Timer _timer;

        protected GameHandler(
            InputListener userInputListener,
            IInputHandler inputHandler,
            IGameRenderer gameRenderer, 
            Timer timer)
        {
            _userInputListener = userInputListener;
            _inputHandler = inputHandler;
            _gameRenderer = gameRenderer;
            _timer = timer;
        }

        public abstract ITypingRace CreateTypingRace();

        public void Run()
        {
            InitGame();
            do
            {
                while (!Console.KeyAvailable)
                {
                    _gameRenderer.Render();
                }
                _userInputListener.Listen();
            } while (_typingRace.State != TypingRaceState.Exit);
        }

        private void InitGame()
        {
            _typingRace = CreateTypingRace();
            _inputHandler.SetTypingRace(_typingRace);
            _gameRenderer.SetTypingRace(_typingRace);
            _userInputListener.SetInputHandler(_inputHandler);
            _timer.Enabled = true;
        }
    }
}
