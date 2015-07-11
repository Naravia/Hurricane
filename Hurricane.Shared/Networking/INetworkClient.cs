using System;
using System.Net;
using Hurricane.Shared.Objects;

namespace Hurricane.Shared.Networking
{
    public interface INetworkClient : IHurricaneObject
    {
        IPAddress ClientIpAddress { get; }

        void SendPacket(INetworkPacket packet);
    }
}