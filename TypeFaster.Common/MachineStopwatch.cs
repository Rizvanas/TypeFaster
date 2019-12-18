using System;
using System.Diagnostics;
using TypeFaster.Common.Contracts;

namespace TypeFaster.Common
{
    public class MachineStopwatch : IStopwatch
    {
        private Stopwatch _stopwatch = new Stopwatch();

        public TimeSpan Elapsed => _stopwatch.Elapsed;

        public bool IsRunning => _stopwatch.IsRunning;

        public void Restart() => _stopwatch.Restart();

        public void Start() => _stopwatch.Start();

        public void Stop() => _stopwatch.Stop();
    }
}
