using System;
using TimeSimulator.Abstractions.Clock;
using TimeSimulator.Abstractions.Tests;
using TimeSimulator.Abstractions.Timer;

namespace TimeSimulator.SystemDateTime.Tests
{
    public class DateTimeBasedTimer : TimerTest<DateTime, TimeSpan>
    {
        protected override Timer<DateTime, TimeSpan> GenerateTimer(ICanAddTime<TimeSpan> clockSubstitute) => new SystemDateTimeTimer(clockSubstitute);

        protected override TimeSpan IntervalInSeconds(int v) => TimeSpan.FromSeconds(v);
    }
}
