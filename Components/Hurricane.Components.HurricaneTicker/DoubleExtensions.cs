using System;

namespace Hurricane.Components.DevHurricaneTicker
{
    internal static class DoubleExtensions
    {
        internal static TimeSpan ToTimeSpan(this Double d)
        {
            return new TimeSpan(0, 0, 0, 0, Convert.ToInt32(d));
        }
    }
}