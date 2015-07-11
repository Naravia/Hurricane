using Hurricane.Shared.Networking;
using Hurricane.Shared.Objects;

namespace Hurricane.Shared.Components.Logon
{
    public interface ILogonClient : IHurricaneObject
    {
        INetworkClient BaseClient { get; }
    }
}