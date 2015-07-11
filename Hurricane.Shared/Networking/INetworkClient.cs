using System;
using System.Net;

namespace Hurricane.Shared.Networking
{
    public interface INetworkClient
    {
        Guid ClientGuid { get; }
        IPAddress ClientIpAddress { get; }

        void SendPacket(INetworkPacket packet);
    }
}