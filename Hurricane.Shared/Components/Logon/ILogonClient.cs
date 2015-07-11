using Hurricane.Shared.Networking;

namespace Hurricane.Shared.Components.Logon
{
    public interface ILogonClient
    {
        INetworkClient BaseClient { get; }
    }
}