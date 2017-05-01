using System;

namespace TimeSimulator.Abstractions.Clock
{
    public abstract class ControllableClockBase<TTime, TInterval> : IClock<TTime>, ICanAddTime<TInterval>
    {
        private object _timeLock = new object();
        
        public TTime Now { get; protected set; }

        public event EventHandler<TimeChangedEventArgs<TInterval>> TimeChanged;

        public void AddInterval(TInterval interval)
        {
            lock (_timeLock)
            {
                Now = Plus(Now, interval);
            }
            TimeMovedForward?.Invoke(this, new TimeChangedEventArgs<TInterval>(interval));
            TimeChanged?.Invoke(this, new TimeChangedEventArgs<TInterval>(interval));
        }

        protected abstract TTime Plus(TTime time, TInterval interval);

        public event EventHandler<TimeChangedEventArgs<TInterval>> TimeMovedForward;
    }
}
