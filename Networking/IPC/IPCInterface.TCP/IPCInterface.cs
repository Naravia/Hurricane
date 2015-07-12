using System;
using Hurricane.Shared.Logging.Interfaces;
using Hurricane.Shared.Networking;
using Hurricane.Shared.Networking.Interfaces;
using Hurricane.Shared.Networking.IPC;
using Hurricane.Shared.Networking.IPC.Interfaces;

namespace Hurricane.Networking.IPC.DevIPCInterface.TCP
{
    public class IPCInterface : IIPCInterface
    {
        public Guid ObjectGuid { get; private set; }

        internal ILogger Log;
        internal IPCInternalRouter Router;
        internal INetworkInterface Network;
        internal IIPCSerialiser Serialiser;
        public event EventHandler<IPCEventArgs> OnReceiveData;

        public IPCInterface(ILogger log, INetworkInterface network, IIPCSerialiser serialiser)
        {
            this.ObjectGuid = Guid.NewGuid();
            this.Log = log;
            this.Router = new IPCInternalRouter(log);
            this.Network = network;
            this.Serialiser = serialiser;
        }

        public Boolean Startup()
        {
            this.Network.OnClientConnecting += NullEvent;
            this.Network.OnClientConnected += NullEvent;
            this.Network.OnReceiveData += this.HandleData;
            this.Network.OnClientDisconnecting += NullEvent;
            this.Network.OnClientDisconnected += NullEvent;

            if (this.Network.Startup())
                return true;

            /* We failed to start up for some reason */
            this.Shutdown();
            return false;
        }

        public Boolean Shutdown()
        {
            this.Network.OnClientConnecting -= NullEvent;
            this.Network.OnClientConnected -= NullEvent;
            this.Network.OnReceiveData -= this.HandleData;
            this.Network.OnClientDisconnecting -= NullEvent;
            this.Network.OnClientDisconnected -= NullEvent;

            return true;
        }

        public Boolean SendIPCMessage(IIPCMessage message)
        {
            /* Do we know this client? */
            if (!this.Router.Clients.ContainsKey(message.TargetGuid))
            {
                this.Log.WriteError(this.ObjectGuid,
                    "Attempted to route {0} to {1}, but there are no known routes for this endpoint. Result: dropping packet",
                    message.ObjectGuid,
                    message.TargetGuid);
                return false;
            }
            
            var data = this.Serialiser.SerialiseIPCMessage(message);
            this.Router.Clients[message.TargetGuid].SendData(data);
            return true;
        }

        private void HandleData(Object sender, NetworkEventArgs e)
        {
            if (this.OnReceiveData == null) return;

            var args = new IPCEventArgs
            {
                Data = e.Data,
                Cancel = false
            };

            this.OnReceiveData(sender, args);

            /* If true, client is kicked */
            e.Cancel = args.Cancel;
        }

        private static void NullEvent(Object sender, NetworkEventArgs e)
        {

        }
    }
}
