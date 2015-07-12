using System;
using Hurricane.Shared.Networking.Interfaces;

namespace Hurricane.Networking.DevNetworker
{
    public class PacketFactory : IPacketFactory
    {
        public PacketFactory()
        {
            this.ObjectGuid = Guid.NewGuid();
        }

        public INetworkPacket CreateNetworkPacket(Byte[] data)
        {
            INetworkPacket packet = new HurricanePacket();
            packet.WriteBytes(data: data);
            packet.Position = 0;
            return packet;
        }

        public Guid ObjectGuid { get; private set; }
    }
}