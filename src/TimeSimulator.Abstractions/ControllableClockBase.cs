using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSimulator.Abstractions
{
    public class ControllableClockBase<TTime, TInterval> : IClock<TTime>, IReportsTimeChange<TInterval>, ICanAddTime<TInterval>
    {
        public TTime Now { get; }

        public event EventHandler<TimeChangedEventArgs<TInterval>> TimeChanged;

        public void AddInterval(TInterval interval)
        {
            throw new NotImplementedException();
        }
    }
}
