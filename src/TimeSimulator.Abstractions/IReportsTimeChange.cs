using System;
using TimeSimulator.Abstractions.Clock;

namespace TimeSimulator.Abstractions
{
    public interface IReportsTimeChange<TInterval>
    {
        event EventHandler<TimeChangedEventArgs<TInterval>> TimeChanged;
    }
}
