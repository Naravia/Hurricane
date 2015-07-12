using System;
using Hurricane.Shared.Components;
using Hurricane.Shared.Logging.Interfaces;
using Hurricane.Shared.Networking.IPC.Interfaces;

namespace Hurricane.Components.Routing.DevRoutingServer
{
    public class RoutingServer : IHurricaneComponent
    {
        public Guid ObjectGuid { get; private set; }
        public ILogger Log { get; private set; }

        internal IIPCHandler IPCHandler;
        internal IIPCInterface IPCInterface;

        public RoutingServer(ILogger log, IIPCHandler ipcHandler, IIPCInterface ipcInterface)
        {
            this.ObjectGuid = Guid.NewGuid();
            this.Log = log;

            this.IPCHandler = ipcHandler;
            this.IPCInterface = ipcInterface;
        }

        public void Initialise()
        {
            throw new NotImplementedException();
        }

        public void Boot()
        {
            throw new NotImplementedException();
        }

        public void Shutdown()
        {
            throw new NotImplementedException();
        }

        public void Tick(TimeSpan timeSinceLastTick)
        {
            throw new NotImplementedException();
        }
    }
}
