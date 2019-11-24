using System;
using TypeFaster.Domain.Entities;
using TypeFaster.GameLogic.Contracts.Input;
using TypeFaster.GameLogic.Contracts.Rendering;
using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.GameLogic.TypingRace.States;

namespace TypeFaster.GameLogic.TypingRace.Instances
{
    public class ClassicTypingRaceInstance : ITypingRaceInstance
    {
        private readonly TypingRaceData _data;
        private readonly IInputHandler _inputHandler;
        private readonly IGameRenderer _gameRenderer;
        private TypingRaceState _state;

        public ClassicTypingRaceInstance(TypingRaceData typingRaceData, IInputHandler inputHandler, IGameRenderer gameRenderer)
        {
            _data = typingRaceData;

            _inputHandler = inputHandler;
            _inputHandler.SetTypingRaceInstance(this);

            _gameRenderer = gameRenderer;
            _gameRenderer.SetTypingRaceInstance(this);

        }

        public void HandleUserInput(ConsoleKeyInfo consoleKeyInfo)
        {
            _state.HandleInput(consoleKeyInfo);
        }

        public void Render()
        {
            _state.Render(this);
        }

        public void AddNewLetter(char letter)
        {
            _data.UserInput += letter;
        }

        public void DeleteLastLetter()
        {
            var userInput = _data.UserInput;
            var lastWordIndex = userInput.Length - 1;

            if (lastWordIndex != -1)
                _data.UserInput = userInput.Remove(lastWordIndex);
        }

        public void ChangeState(TypingRaceState state)
        {
            _state = state;
            _state.SetInputHandler(_inputHandler);
            _state.SetRenderer(_gameRenderer);
        }

    }
}
