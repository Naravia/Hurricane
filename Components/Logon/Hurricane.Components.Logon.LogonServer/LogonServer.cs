using System;
using Hurricane.Components.Logon.LogonServer.Networking;
using Hurricane.Shared.Components;
using Hurricane.Shared.Components.Logon;
using Hurricane.Shared.Logging;
using Hurricane.Shared.Networking;
using Hurricane.Shared.Objects;

namespace Hurricane.Components.Logon.LogonServer
{
    public class LogonServer : IHurricaneComponent
    {
        internal static IHurricaneObjectManager ObjectManager;
        internal static ILogonClientFactory ClientFactory;
        internal static IPacketFactory PacketFactory;
        internal static ILogger Log;
        private readonly INetworkInterface _network;

        public LogonServer(ILogger log, INetworkInterface network, IHurricaneObjectManager objectManager,
            ILogonClientFactory factory, IPacketFactory packetFactory)
        {
            this.ObjectGuid = Guid.NewGuid();

            Log = log;

            this._network = network;
            ObjectManager = objectManager;
            ClientFactory = factory;
            PacketFactory = packetFactory;
        }

        public void Initialise()
        {
        }

        public void Boot()
        {
            /* Register network handlers */
            this._network.OnClientConnecting += NetworkHandlers.OnClientConnecting;
            this._network.OnClientConnected += NetworkHandlers.OnClientConnected;
            this._network.OnReceiveData += NetworkHandlers.OnReceiveData;
            this._network.OnClientDisconnecting += NetworkHandlers.OnClientDisconnecting;
            this._network.OnClientDisconnected += NetworkHandlers.OnClientDisconnected;

            /* Start listening */
            this._network.Startup();
        }

        public void Shutdown()
        {
            /* Stop listening */
            this._network.Shutdown();

            /* Unregister network handlers */
            this._network.OnClientConnecting -= NetworkHandlers.OnClientConnecting;
            this._network.OnClientConnected -= NetworkHandlers.OnClientConnected;
            this._network.OnReceiveData -= NetworkHandlers.OnReceiveData;
            this._network.OnClientDisconnecting -= NetworkHandlers.OnClientDisconnecting;
            this._network.OnClientDisconnected -= NetworkHandlers.OnClientDisconnected;
        }

        public void Tick(TimeSpan timeSinceLastTick)
        {
            /* We don't actually need to do anything here yet */
        }

        public Guid ObjectGuid { get; private set; }
    }
}