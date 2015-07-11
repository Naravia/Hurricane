using System;
using Hurricane.Shared.Networking;
using Hurricane.Shared.Objects;

namespace Hurricane.Shared.Components.Logon
{
    public interface ILogonPacket : INetworkPacket, IOutput
    {
        Byte Opcode { get; set; }
        Byte Error { get; set; }
        UInt16 Size { get; set; }
    }
}