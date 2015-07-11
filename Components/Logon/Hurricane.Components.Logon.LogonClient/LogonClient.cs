using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hurricane.Shared.Components.Logon;
using Hurricane.Shared.Networking;

namespace Hurricane.Components.Logon.LogonClient
{
    public class LogonClient : ILogonClient
    {
        public INetworkClient BaseClient { get; private set; }
        public Guid ObjectGuid { get; private set; }
        public Guid CreatorGuid { get; private set; }

        public LogonClient(Guid creatorGuid)
        {
            ObjectGuid = Guid.NewGuid();
            CreatorGuid = creatorGuid;
        }
    }
}
