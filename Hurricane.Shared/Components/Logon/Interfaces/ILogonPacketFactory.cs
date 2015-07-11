using Hurricane.Shared.Components.Logon.Packets;
using Hurricane.Shared.Networking.Interfaces;
using Hurricane.Shared.Objects.Interfaces;

namespace Hurricane.Shared.Components.Logon.Interfaces
{
    public interface ILogonPacketFactory : IHurricaneObject, IOutput
    {
        ILogonPacket CreateLogonPacket(INetworkPacket packet);
    }
}