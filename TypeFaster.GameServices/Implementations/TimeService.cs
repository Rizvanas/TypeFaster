using System;
using System.Diagnostics;
using TypeFaster.Domain.Entities;
using TypeFaster.GameServices.Contracts;

namespace TypeFaster.GameServices.Implementations
{
    public class TimeService : ITimeService
    {
        private readonly Stopwatch _stopwatch;

        public bool TimerIsRunning => _stopwatch.IsRunning;

        public TimeService(Stopwatch stopwatch)
        {
            _stopwatch = stopwatch;
        }

        public void StartGameTimer()
        {
            _stopwatch.Start();
        }

        public void StopGameTimer()
        {
            _stopwatch.Stop();
        }

        public void ResetGameTimer()
        {
            _stopwatch.Restart();
        }

        public TimeSpan GetGameTimeLeft(TimeSpan duration)
        {
            return duration - _stopwatch.Elapsed;
        }

        public TimeSpan CalculateGameDuration(Sentence sentence)
        {
            var sentenceWordCount = sentence.Words.Split().Length;
            return TimeSpan.FromSeconds(sentenceWordCount * 3);
        }
    }
}
