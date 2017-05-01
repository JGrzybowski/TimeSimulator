using NodaTime;
using TimeSimulator.Abstractions.Clock;
using TimeSimulator.Abstractions.Timer;

namespace TimeSimulator.NodaTime
{
    public class NodaTimer : Timer<Instant, Duration>
    {
        public NodaTimer(ICanAddTime<Duration> clock) : base(clock) { }
        
        public override int AddToBuffer(Duration interval)
        {
            intervalBuffer = intervalBuffer + interval;
            var repetitions = intervalBuffer / Interval;
            if (repetitions > 0)
            {
                intervalBuffer -= ((int)repetitions * Interval);
            }
            return (int)repetitions;
        }
    }
}
