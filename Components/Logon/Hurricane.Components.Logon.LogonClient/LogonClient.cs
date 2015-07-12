using System;
using Hurricane.Shared.Components.Logon.Interfaces;
using Hurricane.Shared.Networking.Interfaces;

namespace Hurricane.Components.Logon.DevLogonClient
{
    public class LogonClient : ILogonClient
    {
        public LogonClient()
        {
            this.ObjectGuid = Guid.NewGuid();
        }

        public LogonClient(INetworkClient client)
        {
            this.BaseClient = client;
        }

        public Guid ObjectGuid { get; private set; }
        public INetworkClient BaseClient { get; private set; }
    }
}