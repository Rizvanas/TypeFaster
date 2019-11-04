using System;
using System.Collections.Generic;
using System.Text;
using TypeFaster.Domain.Contracts;
using TypeFaster.Domain.Entities;
using TypeFaster.GameServices.Contracts;

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

            return new ClassicTypingRace
            {
                Title = "Classic Game",
                StartTime = _timeService.GetGameStartTime(),
                EndTime = _timeService.GetGameEndTime(randomSentence),
                Sentence = randomSentence,
            };
        }
    }
}
