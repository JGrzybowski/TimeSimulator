using NodaTime;
using TimeSimulator.Abstractions;

namespace TimeSimulator.NodaTime
{
    public class NodaTimeControllableClock : ControllableClockBase<Instant, Duration>
    {
        protected override Instant Plus(Instant time, Duration interval) => time.Plus(interval);
    }
}
