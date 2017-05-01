using NSubstitute;
using Shouldly;
using TimeSimulator.Abstractions.Clock;
using TimeSimulator.Abstractions.Timer;
using Xunit;

namespace TimeSimulator.Abstractions.Tests
{
    public abstract class TimerTest<TTime, TInterval>
    {
        [Fact]
        public void rises_the_event_when_time_moves_above_the_interval()
        {
            //Arrange
            var clockSubstitute = Substitute.For<ICanAddTime<TInterval>>();
            var eventCounter = 0;

            var timer = GenerateTimer(clockSubstitute);
            timer.Interval = IntervalInSeconds(5);
            timer.TimerTicked += (sender, args) => eventCounter++;

            //Act
            clockSubstitute.TimeMovedForward += Raise.EventWith(new TimeChangedEventArgs<TInterval>(IntervalInSeconds(6)));
            
            //Assert
            eventCounter.ShouldBe(1);
        }

        [Fact]
        public void rises_the_event_with_proper_repetitions_number_when_time_moves_multiple_above_the_interval()
        {
            //Arrange
            var clockSubstitute = Substitute.For<ICanAddTime<TInterval>>();
            TimerTickedEventArgs eventArgs= null;

            var timer = GenerateTimer(clockSubstitute);
            timer.Interval = IntervalInSeconds(5);
            timer.TimerTicked += (sender, args) => eventArgs = args;

            //Act
            clockSubstitute.TimeMovedForward += Raise.EventWith(new TimeChangedEventArgs<TInterval>(IntervalInSeconds(19)));

            //Assert
            eventArgs.ShouldNotBeNull();
            eventArgs.Repetitions.ShouldBe(3);
        }

        [Fact]
        public void rises_the_event_when_time_sums_up_above_the_interval()
        {
            //Arrange
            var clockSubstitute = Substitute.For<ICanAddTime<TInterval>>();
            var eventCounter = 0;

            var timer = GenerateTimer(clockSubstitute);
            timer.Interval = IntervalInSeconds(5);
            timer.TimerTicked += (sender, args) => eventCounter++;

            //Act
            clockSubstitute.TimeMovedForward += Raise.EventWith(new TimeChangedEventArgs<TInterval>(IntervalInSeconds(4)));
            //Assert
            eventCounter.ShouldBe(0);
            
            //Act
            clockSubstitute.TimeMovedForward += Raise.EventWith(new TimeChangedEventArgs<TInterval>(IntervalInSeconds(4)));
            //Assert
            eventCounter.ShouldBe(1);
        }

        [Fact]
        public void does_not_rise_the_event_when_time_moves_in_less_than_the_interval()
        {
            //Arrange
            var clockSubstitute = Substitute.For<ICanAddTime<TInterval>>();
            var eventCounter = 0;

            var timer = GenerateTimer(clockSubstitute);
            timer.Interval = IntervalInSeconds(5);
            timer.TimerTicked += (sender, args) => eventCounter++;

            //Act
            clockSubstitute.TimeMovedForward += Raise.EventWith(new TimeChangedEventArgs<TInterval>(IntervalInSeconds(4)));

            //Assert
            eventCounter.ShouldBe(0);
        }

        protected abstract TInterval IntervalInSeconds(int v);
        protected abstract Timer<TTime, TInterval> GenerateTimer(ICanAddTime<TInterval> clockSubstitute);
    }
}
