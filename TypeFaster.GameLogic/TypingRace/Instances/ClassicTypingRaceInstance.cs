using System;
using System.Collections.Generic;
using System.Linq;
using TypeFaster.Domain.Entities;
using TypeFaster.GameLogic.Contracts.Input;
using TypeFaster.GameLogic.Contracts.Rendering;
using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.GameLogic.TypingRace.States;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameLogic.TypingRace.Instances
{
    public class ClassicTypingRaceInstance : ITypingRaceInstance
    {
        private readonly TypingRaceData _data;
        private readonly ITimeService _timeService;
        private readonly ITypingCalculator _typingCalculator;
        private readonly IInputHandler _inputHandler;
        private readonly IGameRenderer _gameRenderer;

        public string UserInput => _data.UserInput;
        public string Sentence => _data.Sentence.Words;
        public IDictionary<int, string> Typos => _data.Typos;
        public TimeSpan GameTimeLeft => _timeService.GetGameTimeLeft(_data.EndTime);
        public int TypingSpeed => _typingCalculator.GetNetTypingSpeed(UserInput, _data.StartTime, Typos.Count);
        public decimal TypingAccuracy => _typingCalculator.GetTypingAccuracy(UserInput, _data.StartTime, Typos.Count);
        public TypingRaceState State { get; private set; }
        public bool IsInErrorState => State.GetType() == typeof(ErrorState);
        public bool IsInExitState => State.GetType() == typeof(ExitState);

        public ClassicTypingRaceInstance(
            TypingRaceData typingRaceData,
            ITimeService timeService,
            ITypingCalculator typingCalculator,
            IInputHandler inputHandler, 
            IGameRenderer gameRenderer)
        {
            _data = typingRaceData;
            _timeService = timeService;
            _typingCalculator = typingCalculator;

            _inputHandler = inputHandler;
            _inputHandler.SetTypingRaceInstance(this);

            _gameRenderer = gameRenderer;
            _gameRenderer.SetTypingRaceInstance(this);

            ChangeState(new InitializedState());
        }

        public void HandleUserInput(ConsoleKeyInfo consoleKeyInfo)
        {
            State.HandleInput(consoleKeyInfo);
        }

        public void Render()
        {
            while (!Console.KeyAvailable)
            {
                State.Render(this);
            }
        }

        public void ChangeState(TypingRaceState state)
        {
            State = state;
            State.SetInputHandler(_inputHandler);
            State.SetRenderer(_gameRenderer);
        }

        public bool CheckForInputError()
        {
            return _data.Sentence.Words.StartsWith(_data.UserInput);
        }

        public void UpdateTypos()
        {
            var lastWordIndex = _data.UserInput.Length - 1;
            var lastWord = _data.Sentence.Words.Split().ElementAt(lastWordIndex);

            _data.Typos.TryAdd(lastWordIndex, lastWord);
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
    }
}
