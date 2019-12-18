using NSubstitute;
using NUnit.Framework;
using Shouldly;
using System;
using TypeFaster.GameLogic.Contracts.Input;
using TypeFaster.GameLogic.Contracts.Rendering;
using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.GameLogic.TypingRace;
using TypeFaster.GameLogic.TypingRace.Instances;
using TypeFaster.GameLogic.TypingRace.States;
using TypeFaster.GameServices.Contracts;
using TypeFaster.GameServices.Implementations;

namespace TypeFaster.GameLogic.Tests
{
    public class TypingRaceStateTests
    {
        private TypingRaceState _typingRaceState;
        private ICommandInvoker _commandInvoker;
        private ITimeService _timeService;
        private ITypingRaceInstance _raceInstance;
        private IGameRenderer _gameRenderer;
        private ITypingCalculator _typingCalculator;

        private readonly static string gameTitle = "Test";
        private readonly static string sentence = "Testinis sakinys";
        private readonly static TimeSpan gameDuration = TimeSpan.FromSeconds(10);

        [SetUp]
        public void Setup()
        {
            _typingCalculator = new TypingCalculator();
            _commandInvoker = new CommandInvoker();
            _gameRenderer = Substitute.For<IGameRenderer>();
            _timeService = Substitute.For<ITimeService>();

            _raceInstance = new ClassicTypingRaceInstance(
                title: gameTitle,
                sentence: sentence,
                duration: gameDuration,
                timeService: _timeService,
                typingCalculator: _typingCalculator,
                commandInvoker: _commandInvoker,
                gameRenderer: _gameRenderer);
        }

        [Test]
        [TestCase('t')]
        public void HandleInput_SetsErrorState_WhenInRunningStateAndUserInputIsInvalid(char letter)
        {
            _typingRaceState = new RunningState();
            _typingRaceState.SetCommandInvoker(_commandInvoker);
            _typingRaceState.SetTimeService(_timeService);
            _typingRaceState.SetTypingRaceInstance(_raceInstance);
            _typingRaceState.SetRenderer(_gameRenderer);

            _typingRaceState.HandleInput(new ConsoleKeyInfo(letter, ConsoleKey.T, false, false, false));

            _raceInstance.State.GetType().ShouldBe(typeof(ErrorState));
        }

        [Test]
        [TestCase(' ')]
        public void HandleInput_DoesntDeleteInput_WhenStateIsRunningAndCharIsSpacebar(char letter)
        {
            _typingRaceState = new RunningState();
            _typingRaceState.SetCommandInvoker(_commandInvoker);
            _typingRaceState.SetTimeService(_timeService);
            _typingRaceState.SetTypingRaceInstance(_raceInstance);
            _typingRaceState.SetRenderer(_gameRenderer);

            _typingRaceState.HandleInput(new ConsoleKeyInfo(letter, ConsoleKey.T, false, false, false));
            _typingRaceState.HandleInput(new ConsoleKeyInfo('\b', ConsoleKey.Backspace, false, false, false));

            _raceInstance.UserInput.ShouldBe(letter.ToString());
        }

        [Test]
        [TestCase(' ')]
        public void HandleInput_DeletesInput_WhenStateIsErrorAndCharIsSpacebar(char letter)
        {
            _typingRaceState = new ErrorState();
            _typingRaceState.SetCommandInvoker(_commandInvoker);
            _typingRaceState.SetTimeService(_timeService);
            _typingRaceState.SetTypingRaceInstance(_raceInstance);
            _typingRaceState.SetRenderer(_gameRenderer);

            _typingRaceState.HandleInput(new ConsoleKeyInfo(letter, ConsoleKey.T, false, false, false));
            _typingRaceState.HandleInput(new ConsoleKeyInfo('\b', ConsoleKey.Backspace, false, false, false));

            _raceInstance.UserInput.ShouldBe(string.Empty);
        }
    }
}
