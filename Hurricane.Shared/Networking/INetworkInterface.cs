using System;
using System.Net;

namespace Hurricane.Shared.Networking
{
    public interface INetworkInterface
    {
        Guid InterfaceGuid { get; }
        IPAddress BindAddress { get; set; } // Should deny change while interface is running
        Int32 BindPort { get; set; } // Should deny change while interface is running
        Boolean Running { get; }

        Boolean Startup();
        Boolean Shutdown();

        event EventHandler<NetworkEventArgs> OnClientConnecting;
        event EventHandler<NetworkEventArgs> OnClientConnected;
        event EventHandler<NetworkEventArgs> OnReceiveData;
        event EventHandler<NetworkEventArgs> OnClientDisconnecting;
        event EventHandler<NetworkEventArgs> OnClientDisconnected;
    }
}