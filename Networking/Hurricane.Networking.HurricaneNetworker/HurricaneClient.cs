using System;
using System.Net;
using System.Net.Sockets;
using Hurricane.Shared.Networking;

namespace Hurricane.Networking.HurricaneNetworker
{
    internal class HurricaneClient : INetworkClient
    {
        public HurricaneClient(TcpClient client)
        {
            this.ObjectGuid = Guid.NewGuid();
            this.Client = client;
        }

        public TcpClient Client { get; private set; }

        public void SendPacket(INetworkPacket packet)
        {
            throw new NotImplementedException();
        }

        public Guid ObjectGuid { get; private set; }
    }
}