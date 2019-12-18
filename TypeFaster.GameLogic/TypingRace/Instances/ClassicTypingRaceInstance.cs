using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using TypeFaster.GameLogic.Contracts.Input;
using TypeFaster.GameLogic.Contracts.Rendering;
using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.GameLogic.TypingRace.States;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameLogic.TypingRace.Instances
{
    public class ClassicTypingRaceInstance : ITypingRaceInstance, IObservable
    {
        private string _sentence;
        private readonly ITimeService _timeService;
        private readonly ITypingCalculator _typingCalculator;
        private readonly ICommandInvoker _invoker;
        private readonly IGameRenderer _gameRenderer;
        private readonly List<IObserver> _observers = new List<IObserver>();

        public string Title { get; set; }
        public TimeSpan Duration { get; private set; }

        public string UserInput { get; private set; } = "";
        public string PreErrorInput { get; private set; } = "";
        public int TypingSpeed { get; private set; }
        public decimal TypingAccuracy { get; private set; }
        public TypingRaceState State { get; private set; }
        public bool ShouldExit { get; set; }
        public bool ShouldRestart { get; set; }
        public IDictionary<int, string> Typos { get; private set; } = new Dictionary<int, string>();

        public TimeSpan GameTimeLeft => _timeService.GetGameTimeLeft(Duration);

        public ClassicTypingRaceInstance(
            string title,
            string sentence,
            TimeSpan duration,
            ITimeService timeService,
            ITypingCalculator typingCalculator,
            ICommandInvoker commandInvoker, 
            IGameRenderer gameRenderer)
        {
            _timeService = timeService;
            _typingCalculator = typingCalculator;
            _invoker = commandInvoker;

            _gameRenderer = gameRenderer;
            _gameRenderer.SetTypingRaceInstance(this);

            Title = title;
            Sentence = sentence;
            Duration = duration;
            ShouldExit = false;
            ShouldRestart = false;

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
            if (state == null)
                throw new ArgumentNullException();

            State = state;
            State.SetCommandInvoker(_invoker);
            State.SetTimeService(_timeService);
            State.SetRenderer(_gameRenderer);
            State.SetTypingRaceInstance(this);
        }

        public bool UserHasMadeATypo()
        {
            return !Sentence.StartsWith(UserInput);
        }

        public void UpdateTypos()
        {
            var lastWordIndex = UserInput.Split().Length - 1;
            if (lastWordIndex != -1)
            {
                var lastWord = Sentence.Split().ElementAt(lastWordIndex);
                Typos.TryAdd(lastWordIndex + 1, lastWord);
            }
        }

        public void AddNewLetter(char letter)
        {
            UserInput += letter;
        }

        public void DeleteLastLetter()
        {
            var userInput = UserInput;
            var lastWordIndex = userInput.Length - 1;
            UserInput = userInput.Remove(lastWordIndex);
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
            TypingSpeed = _typingCalculator.GetNetTypingSpeed(
                UserInput, 
                _timeService.GetGameTimeElapsed(),
                Typos.Count);
        }

        public void TrySetToGameOverState(Object source, ElapsedEventArgs e)
        {
            if (_timeService.GetGameTimeElapsed() >= Duration)
            {
                _timeService.StopGameTimer();
                _timeService.DisableEventDispatching();
                ChangeState(new GameOverState());
                Notify();
            }
        }

        public void UpdatePreErrorInput()
        {
            if (PreErrorInput == null || UserInput == null)
                throw new InvalidOperationException();

            PreErrorInput = UserInput;
        }

        public bool GameIsFinished()
        {
            if (Sentence == null || UserInput == null)
                throw new InvalidOperationException();

            return Sentence == UserInput;
        }

        public void UpdateTypingAccuracy()
        {
            TypingAccuracy = _typingCalculator.GetTypingAccuracy(UserInput, Typos.Count);
        }

        public string Sentence
        {
            get => _sentence;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentOutOfRangeException($"Argument cannot be null or whitespace.");

                if (!string.IsNullOrWhiteSpace(_sentence))
                    throw new ArgumentOutOfRangeException($"The value of {nameof(_sentence)} has been already set.");

                _sentence = value;
            }
        }
    }
}
