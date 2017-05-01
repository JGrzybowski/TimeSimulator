namespace TimeSimulator.Abstractions.Clock
{
    public interface IClock<TTime>
    {
        TTime Now { get; }
    }
}
