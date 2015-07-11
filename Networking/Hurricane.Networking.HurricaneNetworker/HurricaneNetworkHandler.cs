using System;
using System.Collections.Generic;
using Hurricane.Shared.Logging;
using Hurricane.Shared.Networking;

namespace Hurricane.Networking.HurricaneNetworker
{
    internal class HurricaneNetworkHandler : INetworkHandler
    {
        private Dictionary<Guid, INetworkInterface> _interfaces = new Dictionary<Guid, INetworkInterface>();

        public HurricaneNetworkHandler(ILogger log)
        {
            this.Log = log;
            this.ObjectGuid = Guid.NewGuid();
        }

        public INetworkInterface CreateInterface()
        {
            throw new NotImplementedException();
        }

        public Boolean DestroyInterface(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Boolean DestroyInterface(INetworkInterface networkInterface)
        {
            throw new NotImplementedException();
        }

        public Guid ObjectGuid { get; private set; }
        public ILogger Log { get; private set; }
    }
}