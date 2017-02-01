using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace TimeSimulator.Abstractions.Tests
{
    public abstract class AddingByInterval<TTime, TInterval> 
    {
        [Fact]
        public void throws_ArgumentOutOfRangeException_when_provided_value_less_than_0()
        {
            var clock = new ControllableClockBase<TTime, TInterval>();
            var interval = GenerateNegativeInterval();

            var ex = Should.Throw<ArgumentOutOfRangeException>(() => clock.AddInterval(interval));

            ex.ParamName.ShouldBe(nameof(interval));
            ex.ActualValue.ShouldBe(interval);
        }

        [Fact]
        public void changes_Now_value_when_provided_value_greater_than_0()
        {
            var clock = new ControllableClockBase<TTime, TInterval>();
            var time = clock.Now;
            var interval = GeneratePositiveInterval();

            clock.AddInterval(interval);

            clock.Now.ShouldBe(time);
        }

        [Fact]
        public void changes_Now_value_when_provided_value_equal_to_0()
        {
            var clock = new ControllableClockBase<TTime, TInterval>();
            var time = clock.Now;
            var interval = GenerateZeroInterval();

            clock.AddInterval(interval);

            clock.Now.ShouldBe(time);
        }

        public abstract TInterval GenerateNegativeInterval();
        public abstract TInterval GenerateZeroInterval();
        public abstract TInterval GeneratePositiveInterval();
    }
}
