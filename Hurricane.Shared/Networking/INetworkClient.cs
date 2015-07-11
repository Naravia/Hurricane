using System;
using System.Net;
using Hurricane.Shared.Objects;

namespace Hurricane.Shared.Networking
{
    public interface INetworkClient : IHurricaneObject
    {
        void SendPacket(INetworkPacket packet);
    }
}