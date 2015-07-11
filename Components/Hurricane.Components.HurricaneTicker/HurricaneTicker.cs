using System;
using System.Threading;
using Hurricane.Shared.Components;
using Timer = System.Timers.Timer;

namespace Hurricane.Components.HurricaneTicker
{
    public class HurricaneTicker : IHurricaneTicker
    {
        private readonly DateTime _startupTime;
        private readonly Thread _thread;
        private readonly Timer _timer;
        private IHurricaneComponent _component;
        private DateTime _lastTick;

        public HurricaneTicker(IHurricaneComponent component)
        {
            TickerGuid = Guid.NewGuid();

            /* Used to calculate running average of ticks */
            TickCount = 0;
            AverageTick = new TimeSpan(0);
            /* Set a very slow tick to force override on first tick */
            FastestTick = new TimeSpan(Int32.MaxValue);
            /* Set a very fast tick to force override on first tick */
            SlowestTick = new TimeSpan(0);

            _component = component;
            _startupTime = DateTime.Now;
            _lastTick = DateTime.Now;

            _timer = new Timer {Enabled = false, Interval = 100.0};
            _timer.Elapsed += InternalTick;
        }

        public Guid TickerGuid { get; private set; }
        public Int64 TickCount { get; private set; }

        public TimeSpan RunningTime
        {
            get { return DateTime.Now - _startupTime; }
        }

        public TimeSpan AverageTick { get; private set; }
        public TimeSpan FastestTick { get; private set; }
        public TimeSpan SlowestTick { get; private set; }
        public TimeSpan LastTick { get { return DateTime.Now - _lastTick; } }

        public TimeSpan Interval
        {
            get { return _timer.Interval.ToTimeSpan(); }
            set { _timer.Interval = value.ToDouble(); }
        }

        public Boolean Enabled
        {
            get { return _timer.Enabled; }
            set { _timer.Enabled = value; }
        }

        private void InternalTick(Object sender, EventArgs e)
        {
            var tickStart = DateTime.Now;

            /* Start Logic */
            _component.Tick(LastTick);
            /* End Logic */

            var tickLength = DateTime.Now - tickStart;

            /* Umm.. should maybe clean this up a bit, but it's pretty self explanatory */
            AverageTick =
                ((((AverageTick.TotalMilliseconds*TickCount) + tickLength.TotalMilliseconds))/++TickCount).ToTimeSpan();

            if (FastestTick.CompareTo(tickLength) == 1)
                FastestTick = tickLength;

            if (SlowestTick.CompareTo(tickLength) == -1)
                SlowestTick = tickLength;

            /* Finally, set the time of the last tick to now */
            _lastTick = DateTime.Now;
        }
    }
}