using System;
using TimeSimulator.Abstractions.Clock;

namespace TimeSimulator.Abstractions.Timer
{
    public abstract class Timer<TTime, TInterval> : ITimer<TInterval>
    {
        protected ICanAddTime<TInterval> clock;

        protected TInterval intervalBuffer;

        public TInterval Interval { get; set; }

        public Timer(ICanAddTime<TInterval> clock)
        {
            this.clock = clock;
            IsRunning = false;
            clock.TimeMovedForward += Clock_TimeMovedForward;
        }

        protected void Clock_TimeMovedForward(object sender, TimeChangedEventArgs<TInterval> e)
        {
            var intervalRepetitions = AddToBuffer(e.TimeDelta);
            if (intervalRepetitions != 0)
                TimerTicked?.Invoke(this, new TimerTickedEventArgs(intervalRepetitions));
        }

        //public void Tick()
        //{

        //}

        public bool IsRunning { get; private set; }

        public void Start() => IsRunning = true;

        public void Stop() => IsRunning = false;

        public void ToggleTimer()
        {
            if (IsRunning) Stop();
            else Start();
        }

        public event EventHandler<TimerTickedEventArgs> TimerTicked;

        public abstract int AddToBuffer(TInterval interval);
    }
}
