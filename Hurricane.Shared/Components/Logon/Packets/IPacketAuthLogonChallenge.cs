using System;

namespace Hurricane.Shared.Components.Logon.Packets
{
    public interface IPacketAuthLogonChallenge
    {
        GameVersionStruct ClientVersion { get; }
        GameLocaleEnum ClientLocale { get; }
        String AccountName { get; }
    }
}