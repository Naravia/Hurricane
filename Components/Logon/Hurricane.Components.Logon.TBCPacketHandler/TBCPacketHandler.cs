using System;
using Hurricane.Components.Logon.TBCPacketHandler.Packets;
using Hurricane.Shared.Components.Logon;
using Hurricane.Shared.Logging;
using Hurricane.Shared.Networking;

namespace Hurricane.Components.Logon.TBCPacketHandler
{
    public class TBCPacketHandler : ILogonPacketHandler
    {
        public TBCPacketHandler(ILogger log)
        {
            this.Log = log;
            this.ObjectGuid = Guid.NewGuid();
        }

        public ILogonPacket ParseNetworkPacket(INetworkPacket packet)
        {
            return new TBCLogonPacket(packet, this.Log);
        }

        public LogonPacketOpcodeEnum GetOpcodeEnum(Byte opcode)
        {
            switch (opcode)
            {
                case 0:
                    return LogonPacketOpcodeEnum.AuthLogonChallenge;
                    break;
                default:
                    return LogonPacketOpcodeEnum.InvalidOpcode;
            }
        }

        public void HandleAuthLogonChallenge(ILogonPacket packet, ILogger log)
        {
            var authpacket = new AuthLogonChallengeHandler(packet);
            var p = authpacket.PacketStruct;
            log.WriteDebug(this.ObjectGuid,
                "Received auth packet:\nOpcode [{0}]\nError [{1}]\nSize [{2}]\nGame [{3}]\nVersion [{4}]\nPlatform [{5}]\nOS [{6}]\nTimezoneBias [{7}]\nIP [{8}]\nAccount [{9}]",
                authpacket.Packet.Opcode, authpacket.Packet.Error, authpacket.Packet.Size, p.GameName, p.Version,
                p.Platform, p.OperatingSystem, p.TimezoneBias, p.IP, p.AccountName);
        }

        public Guid ObjectGuid { get; private set; }
        public ILogger Log { get; private set; }
    }
}