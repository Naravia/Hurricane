using System;
using Hurricane.Shared.Objects.Interfaces;

namespace Hurricane.Shared.Networking.Interfaces
{
    public interface IPacketFactory : IHurricaneObject
    {
        INetworkPacket CreateNetworkPacket(Byte[] data);
    }
}