using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
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
        private readonly ICommandInvoker _invoker;
        private readonly IGameRenderer _gameRenderer;
        private readonly List<IObserver> _observers;

        public string UserInput => _data.UserInput;
        public string PreErrorInput => _data.PreErrorInput;
        public string Sentence => _data.Sentence.Words;
        public IDictionary<int, string> Typos => _data.Typos;
        public TimeSpan GameTimeLeft => _timeService.GetGameTimeLeft(_data.Duration);
        public TypingRaceState State { get; private set; }
        public bool IsInRunningState => State.GetType() == typeof(RunningState);
        public bool IsInErrorState => State.GetType() == typeof(ErrorState);
        public bool IsInPausedState => State.GetType() == typeof(PausedState);
        public bool IsInExitState => State.GetType() == typeof(ExitState);
        public bool IsInInitState => State.GetType() == typeof(InitializedState);
        public bool IsInFinishedState => State.GetType() == typeof(FinishedState);
        public bool IsInWaitingForRestartState => State.GetType() == typeof(WaitingForRestartState);
        public decimal TypingAccuracy => _data.TypingAccuracy;
        public int TypingSpeed => _data.TypingSpeed;

        public ClassicTypingRaceInstance(
            TypingRaceData typingRaceData,
            ITimeService timeService,
            ITypingCalculator typingCalculator,
            ICommandInvoker commandInvoker, 
            IGameRenderer gameRenderer)
        {
            _data = typingRaceData;
            _timeService = timeService;
            _typingCalculator = typingCalculator;
            _invoker = commandInvoker;
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
                State.Render();
            }
        }

        public void ChangeState(TypingRaceState state)
        {
            State = state;
            State.SetCommandInvoker(_invoker);
            State.SetTimeService(_timeService);
            State.SetRenderer(_gameRenderer);
            State.SetTypingRaceInstance(this);
        }

        public bool UserHasMadeATypo()
        {
            return !_data.Sentence.Words.StartsWith(_data.UserInput);
        }

        public void UpdateTypos()
        {
            var lastWordIndex = _data.UserInput.Split().Length - 1;
            if (lastWordIndex != -1)
            {
                var lastWord = _data.Sentence.Words.Split().ElementAt(lastWordIndex);
                _data.Typos.TryAdd(lastWordIndex + 1, lastWord);
            }
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

        public void UpdateTypingSpeed(Object source, ElapsedEventArgs e)
        {
            _data.TypingSpeed = _typingCalculator.GetNetTypingSpeed(
                UserInput, 
                _timeService.GetGameTimeElapsed(),
                Typos.Count);
        }

        public void TrySetToGameOverState(Object source, ElapsedEventArgs e)
        {
            if (_timeService.GetGameTimeElapsed() >= _data.Duration)
            {
                _timeService.StopGameTimer();
                _timeService.DisableEventDispatching();
                Notify();
                ChangeState(new GameOverState());
            }
        }

        public void UpdatePreErrorInput()
        {
            _data.PreErrorInput = _data.UserInput;
        }

        public bool GameIsFinished()
        {
            return Sentence == UserInput;
        }

        public void UpdateTypingAccuracy()
        {
            _data.TypingAccuracy = _typingCalculator.GetTypingAccuracy(UserInput, Typos.Count);
        }
    }
}
