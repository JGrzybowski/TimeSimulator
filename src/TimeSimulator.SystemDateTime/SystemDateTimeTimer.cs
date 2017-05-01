using System;
using TimeSimulator.Abstractions.Clock;
using TimeSimulator.Abstractions.Timer;

namespace TimeSimulator.SystemDateTime
{
    public class SystemDateTimeTimer : Timer<DateTime, TimeSpan>
    {
        public SystemDateTimeTimer(ICanAddTime<TimeSpan> clock) : base(clock) { }

        public override int AddToBuffer(TimeSpan interval)
        {
            this.intervalBuffer = intervalBuffer + interval;
            long repetitions = intervalBuffer.Ticks / Interval.Ticks;
            if (repetitions > 0)
            {
                intervalBuffer -= TimeSpan.FromTicks(repetitions * Interval.Ticks);
            }
            return (int)repetitions;
        }
    }
}
