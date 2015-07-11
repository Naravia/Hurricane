using System;

namespace Hurricane.Shared.Networking
{
    public interface INetworkHandler
    {
        INetworkInterface CreateInterface();
        Boolean DestroyInterface(Guid guid);
        Boolean DestroyInterface(INetworkInterface networkInterface);
    }
}