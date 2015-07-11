using System;
using Hurricane.Shared.Components.Logon.Packets;
using Hurricane.Shared.Logging.Interfaces;
using Hurricane.Shared.Networking.Interfaces;
using Hurricane.Shared.Objects.Interfaces;

namespace Hurricane.Shared.Components.Logon.Interfaces
{
    public interface ILogonPacketHandler : IHurricaneObject, IOutput
    {
        ILogonPacket ParseNetworkPacket(INetworkPacket packet);
        LogonPacketOpcodeEnum GetOpcodeEnum(Byte opcode);
        void HandleAuthLogonChallenge(ILogonPacket packet, ILogger logger);
    }
}