using System;
using System.Net;
using Hurricane.Shared.Objects;

namespace Hurricane.Shared.Networking
{
    public interface INetworkClient : IHurricaneObject, IOutput
    {
        void SendPacket(INetworkPacket packet);
    }
}