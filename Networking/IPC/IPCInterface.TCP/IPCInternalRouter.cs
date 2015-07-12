using System;
using System.Collections.Generic;
using Hurricane.Shared.Logging.Interfaces;
using Hurricane.Shared.Networking.Interfaces;
using Hurricane.Shared.Objects.Interfaces;

namespace Hurricane.Networking.IPC.DevIPCInterface.TCP
{
    internal class IPCInternalRouter : IHurricaneObject
    {
        internal Dictionary<Guid, INetworkClient> Clients = new Dictionary<Guid, INetworkClient>();
        internal ILogger Log;

        public IPCInternalRouter(ILogger log)
        {
            this.ObjectGuid = Guid.NewGuid();
            this.Log = log;
        }

        /* We take the GUID in as a seperate arg because it's the guid the client gives us, not the one we assign */
        internal void RegisterClient(Guid clientGuid, INetworkClient client)
        {
            this.Clients.Add(clientGuid, client);
        }

        public Guid ObjectGuid { get; private set; }
    }
}