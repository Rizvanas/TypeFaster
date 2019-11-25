using System;
using TypeFaster.Common.Contracts;
using TypeFaster.Domain.Entities;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameServices.Implementations
{
    public class TimeService : ITimeService
    {
        IDateTime _dateTime;

        public TimeService(IDateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public int GetWordsPerMinute(TimeSpan timeElapsed, int wordCount)
        {
            var wordsPerMinute = wordCount / timeElapsed.TotalMinutes;
            return Convert.ToInt32(Math.Round(wordsPerMinute));
        }

        public TimeSpan GetGameTimeLeft(DateTime endTime)
        {
            return _dateTime.Now - endTime;
        }

        public DateTime GetGameStartTime()
        {
            return _dateTime.Now;
        }

        public DateTime GetGameEndTime(Sentence sentence)
        {
            var gameDuration = CalculateGameDuration(sentence);
            return _dateTime.Now.Add(gameDuration);
        }

        private TimeSpan CalculateGameDuration(Sentence sentence)
        {
            var sentenceWordCount = sentence.Words.Split().Length;
            return TimeSpan.FromSeconds(sentenceWordCount * 3);
        }
    }
}
