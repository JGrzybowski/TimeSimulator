using System;
using TimeSimulator.Abstractions.Clock;

namespace TimeSimulator.Abstractions
{
    public class TimeSimulator<TTime,TInterval> : ITimeSimulator<TTime,TInterval>
    {
        public event EventHandler<TimeChangedEventArgs<TTime>> TimeMovedForward;

        public void Reset(TTime resetTime)
        {
            throw new NotImplementedException();
        }

        public void Tick()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public bool IsRunning
        {
            get { throw new NotImplementedException(); }
        }

        public void ToggleTimer()
        {
            throw new NotImplementedException();
        }

        public double Speed { get; set; }
        public void AddInterval(TTime interval)
        {
            throw new NotImplementedException();
        }
    }
}
