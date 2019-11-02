using System;
using System.Collections.Generic;
using System.Text;
using TypeFaster.Domain.Contracts;
using TypeFaster.Domain.Entities;
using TypeFaster.GameLogic.Contracts;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameLogic.Implementations
{
    public class ClassicGameHandler : GameHandler
    {
        private readonly ISentenceRotator _sentenceRotator;
        private readonly ITimeService _timeService;

        public ClassicGameHandler(
            UserInputListener userInputListener,
            ITimeService timeService,
            ISentenceRotator sentenceRotator) 
            : base(userInputListener)
        {
            _timeService = timeService;
            _sentenceRotator = sentenceRotator;
        }

        public override ITypingRace CreateTypingRace()
        {
            var sentence = _sentenceRotator.GetNextSentence();

            return new ClassicTypingRace
            {
                Title = "Classic Game",
                StartTime = _timeService.GetGameStartTime(),
                EndTime = _timeService.GetGameEndTime(sentence),
                Sentence = sentence,
                Typos = new List<string>()
            };
        }
    }
}
