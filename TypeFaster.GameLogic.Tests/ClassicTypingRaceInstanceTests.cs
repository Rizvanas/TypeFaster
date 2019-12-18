using NSubstitute;
using NUnit.Framework;
using Shouldly;
using System;
using System.Timers;
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
    public class ChangeStateTestData
    {
        public TypingRaceState State { get; set; }
        public TypingRaceState ExpectedResult { get; set; }
    }

    public class ClassicTypingRaceInstanceTests
    {
        private ITypingRaceInstance _raceInstance;
        private ITimeService _timeService;
        private ITypingCalculator _typingCalculator;
        private ICommandInvoker _commandInvoker;
        private IGameRenderer _gameRenderer;

        private readonly static string gameTitle = "Test";
        private readonly static string sentence = "Labas vakaras, ponai ir ponios!!!!";
        private readonly static TimeSpan gameDuration = TimeSpan.FromSeconds(10);

        private static ChangeStateTestData[] changeStateValidDataSet = new[]
        {
            new ChangeStateTestData
            {
                State = new ErrorState(),
                ExpectedResult = new ErrorState()
            },
            new ChangeStateTestData
            {
                State = new RunningState(),
                ExpectedResult = new RunningState()
            }
        };

        private static ChangeStateTestData[] changeStateInvalidDataSet = new[]
        {
            new ChangeStateTestData
            {
                State = null,
                ExpectedResult = null
            },
            new ChangeStateTestData
            {
                State = null,
                ExpectedResult = null
            }
        };

        [SetUp]
        public void Setup()
        {
            _typingCalculator = new TypingCalculator();
            _commandInvoker = new CommandInvoker();
            _timeService = Substitute.For<ITimeService>();
            _gameRenderer = Substitute.For<IGameRenderer>();


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
        public void ChangedStateHasValidChangesTypingRaceStateWhenInputIsValid(
            [ValueSource("changeStateValidDataSet")]ChangeStateTestData testData)
        {
            _raceInstance.ChangeState(testData.State);
            _raceInstance.State.GetType().ShouldBe(testData.ExpectedResult.GetType());
        }

        [Test]
        public void ChangedStateThrowsArgumentNullExceptionWhenInputIsInvalid(
            [ValueSource("changeStateInvalidDataSet")]ChangeStateTestData testData)
        {
            Should.Throw<ArgumentNullException>(() => 
            _raceInstance.ChangeState(testData.State));
        }

        [Test]
        [TestCase('!')]
        public void AddNewLetterConcatinatesNewLetterToAnExistingUserInput(char letter)
        {
            _raceInstance.AddNewLetter(letter);
            _raceInstance.UserInput.ShouldBe("!");
        }

        [Test]
        [TestCase('r')]
        [TestCase(char.MinValue)]
        public void DeleteLastLetterRemovesLastLetterFromAnExistingSentence(char letter)
        {
            _raceInstance.AddNewLetter(letter);
            _raceInstance.DeleteLastLetter();
            _raceInstance.UserInput.ShouldBe("");
        }

        [Test]
        [TestCase("aaa", 'a')]
        public void GameIsFinishedReturnsTrueWhenUserInputAndSentenceAreEqual(string sentence, char letter)
        {
            _raceInstance = new ClassicTypingRaceInstance(
                title: gameTitle,
                sentence: sentence,
                duration: gameDuration,
                timeService: _timeService,
                typingCalculator: _typingCalculator,
                commandInvoker: _commandInvoker,
                gameRenderer: _gameRenderer);

            _raceInstance.AddNewLetter(letter);
            _raceInstance.AddNewLetter(letter);
            _raceInstance.AddNewLetter(letter);

            _raceInstance.GameIsFinished().ShouldBeTrue();
        }

        [Test]
        public void TrySetToGameOverState_SetsTypingRaceInstanceStateToGameOverState_WhenGameTimeElapsedIsHigherThanOrEqualToGameDuration()
        {
            _timeService.GetGameTimeElapsed().Returns(TimeSpan.FromSeconds(10));
            _raceInstance.TrySetToGameOverState(new object(), new EventArgs() as ElapsedEventArgs);
            _raceInstance.State.GetType().ShouldBe(typeof(GameOverState));
        }

        [Test]
        public void TrySetToGameOverState_DoesntSetTypingRaceInstanceStateToGameOverState_WhenGameTimeElapsedValueIsLowerThanGameDuration()
        {
            _timeService.GetGameTimeElapsed().Returns(TimeSpan.FromSeconds(9));
            _raceInstance.TrySetToGameOverState(new object(), new EventArgs() as ElapsedEventArgs);
            _raceInstance.State.GetType().ShouldBe(typeof(InitializedState));
        }
    }
}
