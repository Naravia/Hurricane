using Hurricane.Shared.Networking.Interfaces;
using Hurricane.Shared.Objects.Interfaces;

namespace Hurricane.Shared.Components.Logon.Interfaces
{
    public interface ILogonClientFactory : IHurricaneObject
    {
        ILogonClient CreateLogonClient(INetworkClient client);
    }
}