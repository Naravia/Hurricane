using System;
using Hurricane.Shared.Networking;

namespace Hurricane.Shared.Components.Logon
{
    public interface ILogonPacket : INetworkPacket
    {
        Byte Opcode { get; set; }
        Byte Error { get; set; }
        UInt16 Size { get; set; }
    }
}