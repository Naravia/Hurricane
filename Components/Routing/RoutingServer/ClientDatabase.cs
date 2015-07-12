using System;
using System.Collections.Generic;
using Hurricane.Shared.Networking.Interfaces;

namespace Hurricane.Components.Routing.DevRoutingServer
{
    internal class ClientDatabase
    {
        internal Dictionary<Guid, INetworkClient> Clients;
    }
}
