using System.Timers;
using TypeFaster.Domain.Entities;
using TypeFaster.GameServices.Contracts;
using TypeFaster.GameServices.Implementations;
using TypeFaster.UI.Contracts;

namespace TypeFaster.GameLogic.Implementations
{
    public class ClassicGameHandler : GameHandler
    {
        private readonly ITimeService _timeService;
        private readonly ITypingCalculator _typingCalculator;
        private readonly ISentenceLoader _sentenceLoader;

        public ClassicGameHandler(
            InputListener userInputListener,
            InputHandler inputHandler,
            ITimeService timeService,
            ITypingCalculator typingCalculator,
            ISentenceLoader sentenceLoader,
            IGameRenderer gameRenderer,
            Timer timer) 
            : base(userInputListener, inputHandler, gameRenderer, timer)
        {
            _timeService = timeService;
            _typingCalculator = typingCalculator;
            _sentenceLoader = sentenceLoader;
        }

        public override ITypingRace CreateTypingRace()
        {
            var randomSentence = _sentenceLoader.GetNextRandomSentence();
            var typingRaceData = new TypingRaceData
            {
                Title = "Classic Game",
                StartTime = _timeService.GetGameStartTime(),
                EndTime = _timeService.GetGameEndTime(randomSentence),
                Sentence = randomSentence,
                UserInput = "",
            };

            var typingRace = new ClassicTypingRace(typingRaceData, _typingCalculator);
            typingRace.Subscribe(_inputHandler);
            typingRace.Subscribe(_gameRenderer);
            _timer.Elapsed += typingRace.OnTimerIntervalEnd;

            return typingRace;
        }
    }
}
