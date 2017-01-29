using System;
using System.Collections.Generic;
using System.Text;

namespace TimeSimulator.Abstractions
{
    public delegate void TimerTickedEventHandler(object sender, EventArgs args);

    public interface IControlledTimer<TInterval>
    {
        event EventHandler<TimerTickedEventArgs> TimerTicked;
    }
}
