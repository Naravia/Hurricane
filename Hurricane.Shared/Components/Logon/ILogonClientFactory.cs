using Hurricane.Shared.Networking;
using Hurricane.Shared.Objects;

namespace Hurricane.Shared.Components.Logon
{
    public interface ILogonClientFactory : IHurricaneObject
    {
        ILogonClient CreateLogonClient(INetworkClient client);
    }
}