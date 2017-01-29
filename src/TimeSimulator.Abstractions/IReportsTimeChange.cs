using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSimulator.Abstractions
{
    public interface IReportsTimeChange<TInterval>
    {
        event EventHandler<TimeChangedEventArgs<TInterval>> TimeChanged;
    }
}
