using System;

namespace Hurricane.Shared.Networking
{
    public interface INetworkInterface
    {
        Guid InterfaceGuid { get; }

        Boolean Startup();
        Boolean Shutdown();

        event EventHandler OnClientConnect;
        event EventHandler OnReceiveData;
        event EventHandler OnSendData;
    }
}