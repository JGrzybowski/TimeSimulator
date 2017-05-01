using System;

namespace TimeSimulator.Abstractions.Timer
{
    public class TimerTickedEventArgs : EventArgs
    {
        public TimerTickedEventArgs(int repetitions)
        {
            Repetitions = repetitions;
        }

        public int Repetitions { get; }
    }
}
