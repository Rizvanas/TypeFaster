using TypeFaster.GameLogic.Contracts.Input;
using TypeFaster.GameLogic.Contracts.Rendering;
using TypeFaster.GameLogic.Contracts.TypingRace;
using TypeFaster.GameLogic.Rendering;
using TypeFaster.GameLogic.TypingRace.Instances;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.Launcher.GameLauncher
{
    public class ClassicGameLauncher : GameLauncher
    {
        private readonly ISentenceLoader _sentenceLoader;
        private readonly ITimeService _timeService;
        private readonly ITypingCalculator _typingCalculator;
        private readonly ICommandInvoker _commandInvoker;
        private readonly IGameRenderer _gameRenderer;

        public ClassicGameLauncher(
            IInputListener inputListener, 
            ISentenceLoader sentenceLoader, 
            ITimeService timeService, 
            ITypingCalculator typingCalculator, 
            ICommandInvoker commandInvoker, 
            IGameRenderer gameRenderer) 
            : base(inputListener)
        {
            _sentenceLoader = sentenceLoader;
            _timeService = timeService;
            _typingCalculator = typingCalculator;
            _commandInvoker = commandInvoker;
            _gameRenderer = gameRenderer;
        }

        public override ITypingRaceInstance CreateTypingRaceInstace()
        {
            var randomSentence = _sentenceLoader.GetNextRandomSentence();

            var classicRace = new ClassicTypingRaceInstance(
                title: "Classic Game",
                sentence: randomSentence.Words,
                duration: _timeService.CalculateGameDuration(randomSentence),
                timeService: _timeService,
                typingCalculator: _typingCalculator,
                commandInvoker: _commandInvoker,
                gameRenderer: new GameRenderer());

            classicRace.Subscribe(_gameRenderer);

            return classicRace;
        }
    }
}
