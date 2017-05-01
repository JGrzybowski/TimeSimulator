using TimeSimulator.Abstractions.Clock;

namespace TimeSimulator.Abstractions
{
    public interface ITimeSimulator<TTime,TInterval> : ICanAddTime<TTime>
    {
        void Reset(TTime resetTime);
    }
}
