using System;
using Hurricane.Shared.Components.Logon;

namespace Hurricane.Components.Logon.DevTBCPacketHandler.Packets
{
    public struct AuthLogonChallenge
    {
        /// <summary>
        ///     WString (Byte)
        ///     Player's account name
        /// </summary>
        public String AccountName;

        /// <summary>
        ///     Byte
        ///     Length of player's account name
        /// </summary>
        public Byte AccountNameLength;

        /// <summary>
        ///     Char[4]
        ///     Name of game (always [WoW\0])
        /// </summary>
        public String GameName;

        /// <summary>
        ///     UInt32
        ///     IP address player is connecting to
        /// </summary>
        public IPv4AddressStruct IP;

        /// <summary>
        ///     Char[4]
        ///     Locale of player (enGB, enUS etc)
        /// </summary>
        public String Locale;

        /// <summary>
        ///     Char[4]
        ///     OS player is on (usually [Win\0])
        /// </summary>
        public String OperatingSystem;

        /// <summary>
        ///     Char[4]
        ///     Platform client is built for (always [x86\0])
        /// </summary>
        public String Platform;

        /// <summary>
        ///     UInt32
        ///     Unknown
        /// </summary>
        public UInt32 TimezoneBias;

        /// <summary>
        ///     Byte Expansion
        ///     Byte Major
        ///     Byte Minor
        ///     UInt16 Build
        ///     Player's game version
        /// </summary>
        public GameVersionStruct Version;
    }
}