using System;
using Hurricane.Shared.Objects;

namespace Hurricane.Shared.Components
{
    /// <summary>
    /// Pulses a HurricaneComponent at a regular interval and provides timing data
    /// </summary>
    public interface IHurricaneTicker : IHurricaneObject
    {
        Int64 TickCount { get; }

        TimeSpan RunningTime { get; }
        TimeSpan AverageTick { get; }
        TimeSpan FastestTick { get; }
        TimeSpan SlowestTick { get; }
        TimeSpan LastTick { get; }

        TimeSpan Interval { get; set; }
        Boolean Enabled { get; set; }
    }
}