using System;
using System.Timers;
using TypeFaster.Common.Contracts;
using TypeFaster.Domain.Entities;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameServices.Implementations
{
    public class TimeService : ITimeService
    {
        private readonly IStopwatch _stopwatch;
        private readonly ITimer _timer;

        public bool TimerIsRunning => _stopwatch.IsRunning;
        public bool EventDispatchingEnabled => _timer.Enabled;

        public TimeService(IStopwatch stopwatch, ITimer timer)
        {
            _stopwatch = stopwatch;
            _timer = timer;
        }

        public void StartGameTimer() => _stopwatch.Start();

        public void StopGameTimer() => _stopwatch.Stop();

        public void RestartGameTimer() => _stopwatch.Restart();

        public TimeSpan GetGameTimeLeft(TimeSpan duration) => duration - _stopwatch.Elapsed;

        public TimeSpan GetGameTimeElapsed() => _stopwatch.Elapsed;

        public void SetTimedEventDispatchInterval(int interval) => _timer.Interval = interval;

        public void AddTimedEvent(ElapsedEventHandler timedEvent) => _timer.Elapsed = timedEvent;

        public void EnableEventDispatching() => _timer.Enabled = true;

        public void DisableEventDispatching() => _timer.Enabled = false;

        public TimeSpan CalculateGameDuration(Sentence sentence)
        {
            if (sentence == null || sentence.Words == null)
                throw new ArgumentException();

            var sentenceWordCount = sentence.Words.Split().Length;
            return TimeSpan.FromSeconds(sentenceWordCount * 3);
        }
    }
}
