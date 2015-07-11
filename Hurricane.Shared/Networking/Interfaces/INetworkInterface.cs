using System;
using System.Net;
using Hurricane.Shared.Objects.Interfaces;

namespace Hurricane.Shared.Networking.Interfaces
{
    public interface INetworkInterface : IHurricaneObject, IOutput
    {
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