using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSimulator.Abstractions
{
    public abstract class ControllableClockBase<TTime, TInterval> : IClock<TTime>, IReportsTimeChange<TInterval>, ICanAddTime<TInterval>
    {
        public TTime Now { get; protected set; }

        public event EventHandler<TimeChangedEventArgs<TInterval>> TimeChanged;

        public void AddInterval(TInterval interval)
        {
            Now = Plus(Now, interval);
            TimeMovedForward?.Invoke(this, new TimeChangedEventArgs<TInterval>(interval));
        }

        protected abstract TTime Plus(TTime time, TInterval interval);

        public event EventHandler<TimeChangedEventArgs<TInterval>> TimeMovedForward;
    }
}
