using TypeFaster.Domain.Entities;
using TypeFaster.GameServices.Contracts;
using TypeFaster.GameServices.Implementations;

namespace TypeFaster.GameLogic.Implementations
{
    public class ClassicGameHandler : GameHandler
    {
        private readonly ITimeService _timeService;
        private readonly ISentenceLoader _sentenceLoader;

        public ClassicGameHandler(
            UserInputListener userInputListener,
            ITimeService timeService,
            ISentenceLoader sentenceLoader) 
            : base(userInputListener)
        {
            _timeService = timeService;
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
                UserInput = new Sentence()
            };

            return new ClassicTypingRace(typingRaceData);
        }
    }
}
