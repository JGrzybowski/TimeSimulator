using System;
using TimeSimulator.Abstractions.Clock;

namespace TimeSimulator.SystemDateTime
{
    public class SystemDateTimeControllableClock : ControllableClockBase<DateTime, TimeSpan>
    {
        public SystemDateTimeControllableClock(DateTime dateTime)
        {
            Now = dateTime;
        }

        protected override DateTime Plus(DateTime time, TimeSpan interval) => time + interval;
    }
}