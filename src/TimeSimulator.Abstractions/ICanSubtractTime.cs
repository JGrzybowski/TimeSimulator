namespace TimeSimulator.Abstractions
{
    public interface ICanSubtractTime
    {
        void SubtractMilliseconds(long milliseconds);
        void SubtractSeconds(long seconds);
        void SubtractMinutes(long minutes);
        void SubtractHours(long hours);
        void SubtractDays(long days);
    }

    public interface ICanSubtractTime<TInterval>
    {
        void SubtractInterval(TInterval interval);
    }
}
