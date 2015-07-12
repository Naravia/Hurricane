using System;

namespace Hurricane.Networking.DevNetworker.Extensions
{
    public static class StringExtensions
    {
        public static String ReverseString(this String str, Boolean trimString = true)
        {
            var c = str.ToCharArray();
            Array.Reverse(c);
            return trimString ? new String(c).Trim('\0') : new String(c);
        }
    }
}