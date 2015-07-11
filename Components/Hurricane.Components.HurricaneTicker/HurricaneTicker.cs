using System;
using System.Threading;
using Hurricane.Shared.Components;
using Hurricane.Shared.Logging.Interfaces;
using Timer = System.Timers.Timer;

namespace Hurricane.Components.HurricaneTicker
{
    public class HurricaneTicker : IHurricaneTicker
    {
        private readonly IHurricaneComponent _component;
        private readonly DateTime _startupTime;
        private readonly Thread _thread;
        private readonly Timer _timer;
        private DateTime _lastTick;

        public HurricaneTicker(IHurricaneComponent component, ILogger log)
        {
            this.ObjectGuid = Guid.NewGuid();

            /* Used to calculate running average of ticks */
            this.TickCount = 0;
            this.AverageTick = new TimeSpan(0);
            /* Set a very slow tick to force override on first tick */
            this.FastestTick = new TimeSpan(Int32.MaxValue);
            /* Set a very fast tick to force override on first tick */
            this.SlowestTick = new TimeSpan(0);

            this._component = component;
            this.Log = log;
            this._startupTime = DateTime.Now;
            this._lastTick = DateTime.Now;

            this._timer = new Timer {Enabled = false, Interval = 100.0};
            this._timer.Elapsed += this.InternalTick;
        }

        public Int64 TickCount { get; private set; }

        public TimeSpan RunningTime
        {
            get { return DateTime.Now - this._startupTime; }
        }

        public TimeSpan AverageTick { get; private set; }
        public TimeSpan FastestTick { get; private set; }
        public TimeSpan SlowestTick { get; private set; }

        public TimeSpan LastTick
        {
            get { return DateTime.Now - this._lastTick; }
        }

        public TimeSpan Interval
        {
            get { return this._timer.Interval.ToTimeSpan(); }
            set { this._timer.Interval = value.ToDouble(); }
        }

        public Boolean Enabled
        {
            get { return this._timer.Enabled; }
            set { this._timer.Enabled = value; }
        }

        public Guid ObjectGuid { get; private set; }
        public ILogger Log { get; private set; }

        private void InternalTick(Object sender, EventArgs e)
        {
            var tickStart = DateTime.Now;

            /* Start Logic */
            this._component.Tick(this.LastTick);
            /* End Logic */

            var tickLength = DateTime.Now - tickStart;

            /* Umm.. should maybe clean this up a bit, but it's pretty self explanatory */
            this.AverageTick =
                ((((this.AverageTick.TotalMilliseconds*this.TickCount) + tickLength.TotalMilliseconds))/++this.TickCount)
                    .ToTimeSpan();

            if (this.FastestTick.CompareTo(tickLength) == 1)
                this.FastestTick = tickLength;

            if (this.SlowestTick.CompareTo(tickLength) == -1)
                this.SlowestTick = tickLength;

            /* Finally, set the time of the last tick to now */
            this._lastTick = DateTime.Now;
        }
    }
}