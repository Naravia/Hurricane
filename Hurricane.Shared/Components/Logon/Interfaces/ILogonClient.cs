using Hurricane.Shared.Networking.Interfaces;
using Hurricane.Shared.Objects.Interfaces;

namespace Hurricane.Shared.Components.Logon.Interfaces
{
    public interface ILogonClient : IHurricaneObject
    {
        INetworkClient BaseClient { get; }
    }
}