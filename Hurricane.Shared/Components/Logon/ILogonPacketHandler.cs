using System;
using Hurricane.Shared.Logging;
using Hurricane.Shared.Networking;
using Hurricane.Shared.Objects;

namespace Hurricane.Shared.Components.Logon
{
    public interface ILogonPacketHandler : IHurricaneObject
    {
        ILogonPacket ParseNetworkPacket(INetworkPacket packet);
        LogonPacketOpcodeEnum GetOpcodeEnum(Byte opcode);
        void HandleAuthLogonChallenge(ILogonPacket packet, ILogger logger);
    }
}