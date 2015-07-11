using Hurricane.Shared.Networking;
using Hurricane.Shared.Objects;

namespace Hurricane.Shared.Components.Logon
{
    public interface ILogonPacketFactory : IHurricaneObject
    {
        ILogonPacket CreateLogonPacket(INetworkPacket packet);
    }
}