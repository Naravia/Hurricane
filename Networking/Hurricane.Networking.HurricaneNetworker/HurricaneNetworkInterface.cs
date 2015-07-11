using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Hurricane.Shared.Networking;

namespace Hurricane.Networking.HurricaneNetworker
{
    internal class HurricaneNetworkInterface : INetworkInterface
    {
        private TcpListener _listener;

        public HurricaneNetworkInterface(Guid interfaceGuid, IPAddress bindAddress, Int32 bindPort)
        {
            InterfaceGuid = interfaceGuid;
            BindAddress = bindAddress;
            BindPort = bindPort;
            Running = false;
        }

        public Guid InterfaceGuid { get; private set; }
        public IPAddress BindAddress { get; set; }
        public Int32 BindPort { get; set; }
        public Boolean Running { get; private set; }

        public Boolean Startup()
        {
            if (OnClientConnecting == null) throw new NotImplementedException("No handler registered for OnClientConnecting");
            if (OnClientConnected == null) throw new NotImplementedException("No handler registered for OnClientConnected");
            if (OnReceiveData == null) throw new NotImplementedException("No handler registered for OnReceiveData");
            if (OnClientDisconnecting == null) throw new NotImplementedException("No handler registered for OnClientDisconnecting");
            if (OnClientDisconnected == null) throw new NotImplementedException("No handler registered for OnClientDisconnected");
                
            _listener = new TcpListener(BindAddress, BindPort);
            _listener.Start();
            throw new NotImplementedException();
        }

        public Boolean Shutdown()
        {
            _listener.Stop();
            throw new NotImplementedException();
        }

        public event EventHandler<NetworkEventArgs> OnClientConnecting;
        public event EventHandler<NetworkEventArgs> OnClientConnected;
        public event EventHandler<NetworkEventArgs> OnReceiveData;
        public event EventHandler<NetworkEventArgs> OnClientDisconnecting;
        public event EventHandler<NetworkEventArgs> OnClientDisconnected;

        private async void ListenerLoop()
        {
            do
            {
                var client = await _listener.AcceptTcpClientAsync();
                // Fire this asynchronously to quickly continue loop
                FireOnClientConnect(client);
            } while (Running);
        }

        private async Task<Boolean> ClientLoop()
        {

            return true;
        }

        private async void FireOnClientConnect(TcpClient client)
        {
            if (OnClientConnecting == null) throw new NotImplementedException("No handler registered for OnClientConnecting");
            if (OnClientConnected == null) throw new NotImplementedException("No handler registered for OnClientConnected");

            var args = new NetworkEventArgs
            {
                Client = new HurricaneClient(client),
                NetworkEvent = NetworkEventEnum.ClientConnecting
            };

            OnClientConnecting(this, args);

            if (args.Cancel)
            {
                /* For some reason we don't want this client, so just dump them quietly */
                return;
            }

            /* We want this client, so start setting things up */
            var stream = client.GetStream();


            OnClientConnected(this, args);
        }

        private async Task FireOnClientDisconnect(TcpClient client)
        {
            if (OnClientDisconnecting == null) throw new NotImplementedException("No handler registered for OnClientDisconnecting");
            if (OnClientDisconnected == null) throw new NotImplementedException("No handler registered for OnClientDisconnected");

        }
    }
}