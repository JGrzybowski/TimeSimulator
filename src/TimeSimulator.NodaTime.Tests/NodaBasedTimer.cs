using NodaTime;
using TimeSimulator.Abstractions.Clock;
using TimeSimulator.Abstractions.Tests;
using TimeSimulator.Abstractions.Timer;

namespace TimeSimulator.NodaTime.Tests
{
    public class NodaBasedTimer : TimerTest<Instant, Duration>
    {
        protected override Timer<Instant, Duration> GenerateTimer(ICanAddTime<Duration> clockSubstitute) => new NodaTimer(clockSubstitute);

        protected override Duration IntervalInSeconds(int v) => Duration.FromSeconds(v);
    }
}
