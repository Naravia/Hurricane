using System;
using Hurricane.Shared.Components.Logon;
using Hurricane.Shared.Networking;

namespace Hurricane.Components.Logon.LogonClient
{
    public class LogonClientFactory : ILogonClientFactory
    {
        public Guid ObjectGuid { get; private set; }
        public ILogonClient CreateLogonClient(INetworkClient client)
        {
            return new LogonClient(client);
        }
    }
}