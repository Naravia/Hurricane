using System;
using System.Net;
using System.Net.Sockets;
using Hurricane.Shared.Logging;
using Hurricane.Shared.Networking;

namespace Hurricane.Networking.HurricaneNetworker
{
    internal class HurricaneClient : INetworkClient
    {
        public HurricaneClient(TcpClient client, ILogger log)
        {
            this.ObjectGuid = Guid.NewGuid();
            this.Client = client;
            this.Log = log;
        }

        public TcpClient Client { get; private set; }

        public void SendPacket(INetworkPacket packet)
        {
            throw new NotImplementedException();
        }

        public Guid ObjectGuid { get; private set; }
        public ILogger Log { get; private set; }
    }
}