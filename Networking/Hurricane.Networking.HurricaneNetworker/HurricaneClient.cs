﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Hurricane.Shared.Networking;

namespace Hurricane.Networking.HurricaneNetworker
{
    class HurricaneClient : INetworkClient
    {
        public Guid ClientGuid { get; private set; }

        public IPAddress ClientIpAddress {
            get
            {
                throw new NotImplementedException();
            }
        }

        private TcpClient _client;

        public HurricaneClient(TcpClient client)
        {
            ClientGuid = Guid.NewGuid();
            _client = client;
        }

        public void SendPacket(INetworkPacket packet)
        {
            throw new NotImplementedException();
        }
    }
}