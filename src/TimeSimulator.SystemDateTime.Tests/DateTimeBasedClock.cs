using System;
using TimeSimulator.Abstractions.Tests;

namespace TimeSimulator.SystemDateTime.Tests
{
    public class DateTimeBasedClock : AddingByInterval<DateTime, TimeSpan>
    {
        public override TimeSpan GenerateNegativeInterval() => TimeSpan.FromMinutes(-5);

        public override TimeSpan GenerateZeroInterval() => TimeSpan.Zero;

        public override TimeSpan GeneratePositiveInterval() => TimeSpan.FromMinutes(5);
    }
}
