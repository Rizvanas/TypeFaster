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
    public class ClassicTypingRaceInstance : ITypingRaceInstance, IObservable
    {
        private readonly TypingRaceData _data;
        private readonly ITimeService _timeService;
        private readonly ITypingCalculator _typingCalculator;
        private readonly IInputHandler _inputHandler;
        private readonly IGameRenderer _gameRenderer;
        private readonly List<IObserver> _observers;

        public string UserInput => _data.UserInput;
        public string Sentence => _data.Sentence.Words;
        public IDictionary<int, string> Typos => _data.Typos;
        public TimeSpan GameTimeLeft => _timeService.GetGameTimeLeft(_data.Duration);
        public TypingRaceState State { get; private set; }
        public bool IsInErrorState => State.GetType() == typeof(ErrorState);
        public bool IsInExitState => State.GetType() == typeof(ExitState);
        public decimal TypingAccuracy => _data.TypingAccuracy;
        public int TypingSpeed => _data.TypingSpeed;

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

            _observers = new List<IObserver>();

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
            Notify();
        }

        public bool UserHasMadeATypo()
        {
            return !_data.Sentence.Words.StartsWith(_data.UserInput);
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

            _data.UserInput = userInput.Remove(lastWordIndex);
        }

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Update(State);
            }
        }

        public void ToggleTimer()
        {
            if (_timeService.TimerIsRunning)
                _timeService.StopGameTimer();
            else
                _timeService.StartGameTimer();
        }

        public void RestartTimer()
        {
            _timeService.ResetGameTimer();
        }

        public void UpdateTypingSpeed()
        {
            _data.TypingSpeed = _typingCalculator.GetNetTypingSpeed(
                UserInput, 
                _timeService.GetGameTimeLeft(_data.Duration), 
                Typos.Count);
        }

        public void UpdateTypingAccuracy()
        {
            _data.TypingAccuracy = _typingCalculator.GetTypingAccuracy(UserInput, GameTimeLeft, Typos.Count);
        }
    }
}
