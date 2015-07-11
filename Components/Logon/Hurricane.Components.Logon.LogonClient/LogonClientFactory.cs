using System;
using Hurricane.Shared.Components.Logon.Interfaces;
using Hurricane.Shared.Networking.Interfaces;

namespace Hurricane.Components.Logon.LogonClient
{
    public class LogonClientFactory : ILogonClientFactory
    {
        public LogonClientFactory()
        {
            this.ObjectGuid = Guid.NewGuid();
        }

        public Guid ObjectGuid { get; private set; }

        public ILogonClient CreateLogonClient(INetworkClient client)
        {
            return new LogonClient(client);
        }
    }
}