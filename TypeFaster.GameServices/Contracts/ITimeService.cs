using System;
using TypeFaster.Domain.Entities;

namespace TypeFaster.GameServices.Contracts
{
    public interface ITimeService
    {
        int GetWordsPerMinute(TimeSpan timeElapsed, int wordCount);
        TimeSpan GetGameTimeLeft(DateTime endTime);
        DateTime GetGameStartTime();
        DateTime GetGameEndTime(Sentence sentence);
    }
}
