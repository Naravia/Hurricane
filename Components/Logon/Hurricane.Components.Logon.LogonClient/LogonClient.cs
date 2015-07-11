using System;
using Hurricane.Shared.Components.Logon;
using Hurricane.Shared.Networking;

namespace Hurricane.Components.Logon.LogonClient
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