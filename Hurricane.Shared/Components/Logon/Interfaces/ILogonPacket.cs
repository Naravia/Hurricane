using System;
using Hurricane.Shared.Networking.Interfaces;
using Hurricane.Shared.Objects.Interfaces;

namespace Hurricane.Shared.Components.Logon.Interfaces
{
    public interface ILogonPacket : INetworkPacket, IOutput
    {
        Byte Opcode { get; set; }
        Byte Error { get; set; }
        UInt16 Size { get; set; }
    }
}