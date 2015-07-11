using System;

namespace Hurricane.Shared.Networking
{
    public interface INetworkHandler
    {
        Guid NetworkHandlerGuid { get; }

        INetworkInterface CreateInterface();
        Boolean DestroyInterface(Guid guid);
        Boolean DestroyInterface(INetworkInterface networkInterface);
    }
}