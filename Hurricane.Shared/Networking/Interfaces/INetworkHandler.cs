using System;
using Hurricane.Shared.Objects.Interfaces;

namespace Hurricane.Shared.Networking.Interfaces
{
    public interface INetworkHandler : IHurricaneObject, IOutput
    {
        INetworkInterface CreateInterface();
        Boolean DestroyInterface(Guid guid);
        Boolean DestroyInterface(INetworkInterface networkInterface);
    }
}