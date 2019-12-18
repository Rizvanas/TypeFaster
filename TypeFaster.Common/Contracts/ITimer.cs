
using System.Timers;

namespace TypeFaster.Common.Contracts
{
    public interface ITimer
    {
        double Interval { get; set; }
        bool Enabled { get; set; }
        ElapsedEventHandler Elapsed { set; }
    }
}
