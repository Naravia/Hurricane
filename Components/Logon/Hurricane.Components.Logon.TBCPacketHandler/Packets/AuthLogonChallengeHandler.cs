using System;
using Hurricane.Shared.Components.Logon;
using Hurricane.Shared.Components.Logon.Interfaces;
using Hurricane.Shared.Components.Logon.Packets;

namespace Hurricane.Components.Logon.DevTBCPacketHandler.Packets
{
    public class AuthLogonChallengeHandler : IPacketAuthLogonChallenge
    {
        public ILogonPacket Packet;
        public AuthLogonChallenge PacketStruct;

        public AuthLogonChallengeHandler(ILogonPacket packet)
        {
            this.Packet = packet;
            this.PacketStruct = new AuthLogonChallenge();
            this.PacketStruct.GameName = packet.ReadFixedString(4, true);
            this.PacketStruct.Version.Expansion = packet.ReadByte();
            this.PacketStruct.Version.Major = packet.ReadByte();
            this.PacketStruct.Version.Minor = packet.ReadByte();
            this.PacketStruct.Version.Build = packet.ReadUInt16(false);
            this.PacketStruct.Platform = packet.ReadFixedString(4, true);
            this.PacketStruct.OperatingSystem = packet.ReadFixedString(4, true);
            this.PacketStruct.Locale = packet.ReadFixedString(4, true);
            this.PacketStruct.TimezoneBias = packet.ReadUInt32(false);
            this.PacketStruct.IP.Block1 = packet.ReadByte();
            this.PacketStruct.IP.Block2 = packet.ReadByte();
            this.PacketStruct.IP.Block3 = packet.ReadByte();
            this.PacketStruct.IP.Block4 = packet.ReadByte();
            this.PacketStruct.AccountName = packet.ReadBString(false);
        }

        public GameVersionStruct ClientVersion { get; private set; }
        public GameLocaleEnum ClientLocale { get; private set; }
        public String AccountName { get; private set; }
    }
}