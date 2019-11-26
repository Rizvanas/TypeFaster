using System;
using TypeFaster.Domain.Entities;

namespace TypeFaster.GameServices.Contracts
{
    public interface ITimeService
    {
        bool TimerIsRunning { get; }

        void StartGameTimer();
        void StopGameTimer();
        void ResetGameTimer();
        TimeSpan GetGameTimeLeft(TimeSpan duration);
        TimeSpan CalculateGameDuration(Sentence sentence);
    }
}
