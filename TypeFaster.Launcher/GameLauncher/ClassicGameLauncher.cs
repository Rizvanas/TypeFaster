using System.Collections.Generic;
using TypeFaster.Domain.Entities;
using TypeFaster.GameLogic.Contracts.Input;
using TypeFaster.GameLogic.Contracts.Rendering;
using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.GameLogic.TypingRace.Instances;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.Launcher.GameLauncher
{
    public class ClassicGameLauncher : GameLauncher
    {
        private readonly ISentenceLoader _sentenceLoader;
        private readonly ITimeService _timeService;
        private readonly ITypingCalculator _typingCalculator;
        private readonly IInputHandler _inputHandler;
        private readonly IGameRenderer _gameRenderer;

        public ClassicGameLauncher(
            IInputListener inputListener, 
            ISentenceLoader sentenceLoader, 
            ITimeService timeService, 
            ITypingCalculator typingCalculator, 
            IInputHandler inputHandler, 
            IGameRenderer gameRenderer) 
            : base(inputListener)
        {
            _sentenceLoader = sentenceLoader;
            _timeService = timeService;
            _typingCalculator = typingCalculator;
            _inputHandler = inputHandler;
            _gameRenderer = gameRenderer;
        }

        public override ITypingRaceInstance CreateTypingRaceInstace()
        {
            var randomSentence = _sentenceLoader.GetNextRandomSentence();

            var typingRaceData = new TypingRaceData
            {
                Title = "Classic Game",
                Sentence = randomSentence,
                UserInput = "",
                PreErrorInput = "",
                Typos = new Dictionary<int, string>(),
                Duration = _timeService.CalculateGameDuration(randomSentence)
            };

            var classicRace = new ClassicTypingRaceInstance(
                typingRaceData: typingRaceData,
                timeService: _timeService,
                typingCalculator: _typingCalculator, 
                inputHandler: _inputHandler,
                gameRenderer: _gameRenderer);

            classicRace.Subscribe(_gameRenderer);

            return classicRace;
        }
    }
}
