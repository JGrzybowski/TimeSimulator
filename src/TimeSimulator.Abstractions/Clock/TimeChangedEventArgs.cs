using System;

namespace TimeSimulator.Abstractions.Clock
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
