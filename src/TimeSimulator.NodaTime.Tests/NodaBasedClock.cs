using NodaTime;
using TimeSimulator.Abstractions.Tests;

namespace TimeSimulator.NodaTime.Tests
{
    public class NodaBasedClock : AddingByInterval<Instant, Duration>
    {
        public override Duration GenerateNegativeInterval() => Duration.FromMinutes(-5);

        public override Duration GenerateZeroInterval() => Duration.Zero;

        public override Duration GeneratePositiveInterval() => Duration.FromMinutes(5);
    }
}
