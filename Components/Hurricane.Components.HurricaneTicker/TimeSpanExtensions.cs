using System;

namespace Hurricane.Components.HurricaneTicker
{
    internal static class TimeSpanExtensions
    {
        internal static Double ToDouble(this TimeSpan t)
        {
            return Convert.ToDouble(t.TotalMilliseconds);
        }
    }
}