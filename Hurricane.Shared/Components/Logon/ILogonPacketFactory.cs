using Hurricane.Shared.Networking;
using Hurricane.Shared.Objects;

namespace Hurricane.Shared.Components.Logon
{
    public interface ILogonPacketFactory : IHurricaneObject, IOutput
    {
        ILogonPacket CreateLogonPacket(INetworkPacket packet);
    }
}