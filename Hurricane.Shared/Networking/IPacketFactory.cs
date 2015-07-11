using Hurricane.Shared.Objects;

namespace Hurricane.Shared.Networking
{
    public interface IPacketFactory : IHurricaneObject
    {
        INetworkPacket CreateNetworkPacket(byte[] data);
    }
}