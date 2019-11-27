using System;
using System.Timers;
using TypeFaster.Domain.Entities;

namespace TypeFaster.GameServices.Contracts
{
    public interface ITimeService
    {
        bool TimerIsRunning { get; }
        bool EventDispatchingEnabled { get; }

        void StartGameTimer();
        void StopGameTimer();
        void RestartGameTimer();
        TimeSpan GetGameTimeLeft(TimeSpan duration);
        TimeSpan GetGameTimeElapsed();
        TimeSpan CalculateGameDuration(Sentence sentence);
        void SetTimedEventDispatchInterval(int interval);
        void AddTimedEvent(ElapsedEventHandler timedEvent);
        void EnableEventDispatching();
        void DisableEventDispatching();
    }
}
