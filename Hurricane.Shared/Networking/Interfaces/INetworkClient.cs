using Hurricane.Shared.Objects.Interfaces;

namespace Hurricane.Shared.Networking.Interfaces
{
    public interface INetworkClient : IHurricaneObject, IOutput
    {
        void SendPacket(INetworkPacket packet);
    }
}