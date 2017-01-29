using System;

namespace TimeSimulator.Abstractions
{
    public class TimeChangedEventArgs<TInterval> : EventArgs
    {
        public TInterval TimeDelta { get; }

        public TimeChangedEventArgs(TInterval timeDelta)
        {
            TimeDelta = timeDelta;
        }
    }
}
