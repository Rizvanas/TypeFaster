using System;

namespace TypeFaster.Common.Contracts
{
    public interface IStopwatch
    {
        void Start();
        void Stop();
        void Restart();
        TimeSpan Elapsed { get; }
        bool IsRunning { get; }
    }
}
