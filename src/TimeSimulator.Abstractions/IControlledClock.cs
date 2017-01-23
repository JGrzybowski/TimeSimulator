namespace TimeSimulator.Abstractions
{
    public interface IControlledClock<TTime, TInterval>
    {
        TTime Now { get; }
    }
}
