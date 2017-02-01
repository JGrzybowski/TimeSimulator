using System;
using TimeSimulator.Abstractions.Tests;

namespace TimeSimulator.SystemDateTime.Tests
{
    public class DateTimeBasedClock : AddingByInterval<SystemDateTimeControllableClock ,DateTime, TimeSpan>
    {
        public override TimeSpan GenerateNegativeInterval() => TimeSpan.FromMinutes(-5);

        public override TimeSpan GenerateZeroInterval() => TimeSpan.Zero;

        public override TimeSpan GeneratePositiveInterval() => TimeSpan.FromMinutes(5);

        public override DateTime TimePlusInterval(DateTime time, TimeSpan interval) => time + interval;

        public override SystemDateTimeControllableClock GenerateTestedObject()
        {
            return new SystemDateTimeControllableClock(new DateTime(2017,01,31));
        }
    }
}
