using System;
using System.Collections.Generic;
using Hurricane.Shared.Networking;

namespace Hurricane.Networking.HurricaneNetworker
{
    internal class HurricaneNetworkHandler : INetworkHandler
    {
        private Dictionary<Guid, INetworkInterface> _interfaces = new Dictionary<Guid, INetworkInterface>();

        public HurricaneNetworkHandler(Guid networkHandlerGuid)
        {
            NetworkHandlerGuid = networkHandlerGuid;
        }

        public Guid NetworkHandlerGuid { get; private set; }

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
    }
}