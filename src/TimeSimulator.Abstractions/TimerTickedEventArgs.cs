using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSimulator.Abstractions
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
