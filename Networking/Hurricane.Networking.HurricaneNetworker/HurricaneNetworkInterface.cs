using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Hurricane.Shared.Logging.Interfaces;
using Hurricane.Shared.Networking;
using Hurricane.Shared.Networking.Interfaces;

namespace Hurricane.Networking.DevNetworker
{
    public class HurricaneNetworkInterface : INetworkInterface
    {
        private TcpListener _listener;

        public HurricaneNetworkInterface(IPAddress bindAddress, Int32 bindPort, ILogger log)
        {
            this.ObjectGuid = Guid.NewGuid();

            this.BindAddress = bindAddress;
            this.BindPort = bindPort;
            this.Log = log;
            this.Running = false;
        }

        public IPAddress BindAddress { get; set; }
        public Int32 BindPort { get; set; }
        public Boolean Running { get; private set; }

        public Boolean Startup()
        {
            if (this.OnClientConnecting == null)
                throw new NotImplementedException("No handler registered for OnClientConnecting");
            if (this.OnClientConnected == null)
                throw new NotImplementedException("No handler registered for OnClientConnected");
            if (this.OnReceiveData == null)
                throw new NotImplementedException("No handler registered for OnReceiveData");
            if (this.OnClientDisconnecting == null)
                throw new NotImplementedException("No handler registered for OnClientDisconnecting");
            if (this.OnClientDisconnected == null)
                throw new NotImplementedException("No handler registered for OnClientDisconnected");

            try
            {
                this._listener = new TcpListener(this.BindAddress, this.BindPort);
                this._listener.Start();
                this.ListenerLoop();
            }
            catch (Exception ex)
            {
                this.Log.WriteFatal(this.ObjectGuid, "Could not start listener on {0}:{1}\n{2}",
                    this.BindAddress.ToString(), this.BindPort, ex.ToString());
                return false;
            }
            return true;
        }

        public Boolean Shutdown()
        {
            this._listener.Stop();
            throw new NotImplementedException();
        }

        public event EventHandler<NetworkEventArgs> OnClientConnecting;
        public event EventHandler<NetworkEventArgs> OnClientConnected;
        public event EventHandler<NetworkEventArgs> OnReceiveData;
        public event EventHandler<NetworkEventArgs> OnClientDisconnecting;
        public event EventHandler<NetworkEventArgs> OnClientDisconnected;
        public Guid ObjectGuid { get; private set; }
        public ILogger Log { get; private set; }

        private async void ListenerLoop()
        {
            do
            {
                var client = await this._listener.AcceptTcpClientAsync();
                // Fire this asynchronously to quickly continue loop
                this.FireOnClientConnect(client);
            } while (this.Running);
        }

        /// <summary>
        ///     Constantly reads data from the client and fires OnReceiveData until client goes away
        /// </summary>
        /// <returns>true if client went away without error, false if something went wrong and an exception was thrown</returns>
        private async Task<Boolean> ClientLoop(HurricaneClient client)
        {
            if (this.OnReceiveData == null)
                throw new NotImplementedException("No handler registered for OnReceiveData");

            try
            {
                var stream = client.Client.GetStream();
                while (client.Client.Connected)
                {
                    var buffer = new Byte[4096];
                    this.Log.WriteTrace(this.ObjectGuid, "Waiting to read data from {0}", client.ObjectGuid);
                    var bytesRead = await stream.ReadAsync(buffer, 0, 4096);
                    if (bytesRead == 0)
                    {
                        /* Client has disconnected */
                        this.Log.WriteDebug(this.ObjectGuid, "{0} sent 0 bytes (disconnected)", client.ObjectGuid);
                        return true;
                    }
                    this.Log.WriteTrace(this.ObjectGuid, "{0} sent {1} bytes", client.ObjectGuid, bytesRead);

                    var args = new NetworkEventArgs
                    {
                        Cancel = false,
                        Client = client,
                        Data = buffer.Take(bytesRead).ToArray()
                    };
                    this.OnReceiveData(this, args);
                    if (args.Cancel)
                    {
                        /* We want to kick the client for some reason. Whatever, bye */
                        this.Log.WriteDebug(this.ObjectGuid, "{0} is being kicked by the server (disconnected)",
                            client.ObjectGuid);
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                this.Log.WriteError(this.ObjectGuid, "Failed to read data from [{0}]", client.ObjectGuid);
                this.Log.WriteError(this.ObjectGuid, ex.ToString());
                return false;
            }
            return true;
        }

        private void KillClient(TcpClient client)
        {
            /* For some reason we don't want this client, so just dump them */
            try
            {
                if (client == null) return;

                client.GetStream().Close(0);
                client.Close();
            }
            catch
            {
                /* We don't care if this fails for some reason */
            }
        }

        private async void FireOnClientConnect(TcpClient client)
        {
            if (this.OnClientConnecting == null)
                throw new NotImplementedException("No handler registered for OnClientConnecting");
            if (this.OnClientConnected == null)
                throw new NotImplementedException("No handler registered for OnClientConnected");

            var managedClient = new HurricaneClient(client, this.Log);
            var args = new NetworkEventArgs
            {
                Client = managedClient
            };

            this.OnClientConnecting(this, args);

            if (args.Cancel)
            {
                this.KillClient(client);
                return;
            }

            this.OnClientConnected(this, args);

            if (args.Cancel)
            {
                this.KillClient(client);
                return;
            }

            /* If we're here, we're ready to start receiving data */
            var sessionEndedGracefully = await this.ClientLoop(managedClient);
            this.KillClient(managedClient.Client);
        }

        private async Task FireOnClientDisconnect(TcpClient client)
        {
            if (this.OnClientDisconnecting == null)
                throw new NotImplementedException("No handler registered for OnClientDisconnecting");
            if (this.OnClientDisconnected == null)
                throw new NotImplementedException("No handler registered for OnClientDisconnected");
        }
    }
}