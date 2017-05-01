using System;

namespace TimeSimulator.Abstractions.Timer
{
    public interface ITimer<TInterval>
    {
        // Timer
        TInterval Interval { get; set; }

        void Start();

        void Stop();

        bool IsRunning { get; }

        void ToggleTimer();

        event EventHandler<TimerTickedEventArgs> TimerTicked;
    }
}
