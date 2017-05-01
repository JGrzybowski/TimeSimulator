using Shouldly;
using System;
using TimeSimulator.Abstractions.Clock;
using Xunit;

namespace TimeSimulator.Abstractions.Tests
{
    public abstract class AddingByInterval<TTestedClass, TTime, TInterval> where TTestedClass : ControllableClockBase<TTime, TInterval>
    {
        [Fact]
        public void changes_Now_value_when_provided_value_less_than_0()
        {
            var clock = GenerateTestedObject();
            var time = clock.Now;
            var interval = GenerateNegativeInterval();

            clock.AddInterval(interval);

            clock.Now.ShouldBe(TimePlusInterval(time, interval));
        }

        [Fact]
        public void changes_Now_value_when_provided_value_greater_than_0()
        {
            var clock = GenerateTestedObject();
            var time = clock.Now;
            var interval = GeneratePositiveInterval();

            clock.AddInterval(interval);

            clock.Now.ShouldBe(TimePlusInterval(time, interval));
        }

        [Fact]
        public void changes_Now_value_when_provided_value_equal_to_0()
        {
            var clock = GenerateTestedObject();
            var time = clock.Now;
            var interval = GenerateZeroInterval();

            clock.AddInterval(interval);

            clock.Now.ShouldBe(time);
        }

        [Fact]
        public void fires_TimeMovedForward_event()
        {
            //Arrange
            var clock = GenerateTestedObject();
            var interval = GeneratePositiveInterval();

            var eventFired = false;
            TInterval eventInterval = default(TInterval);

            var onTimeMovedForward = new EventHandler<TimeChangedEventArgs<TInterval>>((sender, args) =>
                {
                 eventFired = true;
                 eventInterval = args.TimeDelta;
                }
            );
            clock.TimeMovedForward += onTimeMovedForward;


            //Act
            clock.AddInterval(interval);

            //Assert
            eventFired.ShouldBeTrue();
            eventInterval.ShouldBe(interval);
        }

        public abstract TTestedClass GenerateTestedObject();

        public abstract TInterval GenerateNegativeInterval();
        public abstract TInterval GenerateZeroInterval();
        public abstract TInterval GeneratePositiveInterval();

        public abstract TTime TimePlusInterval(TTime time, TInterval interval);
    }
}
