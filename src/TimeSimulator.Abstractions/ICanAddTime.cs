namespace TimeSimulator.Abstractions
{
    public interface ICanAddTime
    {
        void AddMilliseconds (long milliseconds);
        void AddSeconds (long seconds);
        void AddMinutes (long minutes);
        void AddHours (long hours);
        void AddDays (long days);
    }

    public interface ICanAddTime<TInterval>
    {
        void AddInterval(TInterval interval);
    }
}
