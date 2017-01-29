namespace TimeSimulator.Abstractions
{
    public interface IClock<TTime>
    {
        TTime Now { get; }
    }
}
