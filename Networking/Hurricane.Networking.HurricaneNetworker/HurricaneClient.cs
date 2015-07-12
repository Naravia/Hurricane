using System;
using System.Net.Sockets;
using Hurricane.Shared.Logging.Interfaces;
using Hurricane.Shared.Networking.Interfaces;

namespace Hurricane.Networking.DevNetworker
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

        public void SendData(Byte[] data)
        {
            this.Client.GetStream().Write(data, 0, data.Length);
        }

        public Guid ObjectGuid { get; private set; }
        public ILogger Log { get; private set; }
    }
}