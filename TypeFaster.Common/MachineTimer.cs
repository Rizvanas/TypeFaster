using System.Timers;
using TypeFaster.Common.Contracts;

namespace TypeFaster.Common
{
    public class MachineTimer : ITimer
    {
        private Timer _timer = new Timer();
        public double Interval { get => _timer.Interval; set => _timer.Interval = value; }
        public bool Enabled { get => _timer.Enabled; set => _timer.Enabled = value; }
        ElapsedEventHandler ITimer.Elapsed { set => _timer.Elapsed += value; }
    }
}
