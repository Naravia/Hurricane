using System;
using Hurricane.Shared.Objects;

namespace Hurricane.Shared.Networking
{
    public interface INetworkHandler : IHurricaneObject
    {
        INetworkInterface CreateInterface();
        Boolean DestroyInterface(Guid guid);
        Boolean DestroyInterface(INetworkInterface networkInterface);
    }
}