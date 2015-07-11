﻿using System;
using System.Threading;
using Hurricane.Components.Logon.LogonServer.Networking;
using Hurricane.Shared.Components;
using Hurricane.Shared.Logging;
using Hurricane.Shared.Networking;

namespace Hurricane.Components.Logon.LogonServer
{
    public class LogonServer : IHurricaneComponent
    {
        private readonly LoggerCollection _log;
        private readonly INetworkInterface _network;

        public LogonServer(LoggerCollection log, INetworkInterface network)
        {
            ObjectGuid = Guid.NewGuid();

            _log = log;

            _network = network;
        }

        public void Initialise()
        {

        }

        public void Boot()
        {
            /* Register network handlers */
            _network.OnClientConnecting += NetworkHandlers.OnClientConnecting;
            _network.OnClientConnected += NetworkHandlers.OnClientConnected;
            _network.OnReceiveData += NetworkHandlers.OnReceiveData;
            _network.OnClientDisconnecting += NetworkHandlers.OnClientDisconnecting;
            _network.OnClientDisconnected += NetworkHandlers.OnClientDisconnected;
        }

        public void Shutdown()
        {
            /* Unregister network handlers */
            _network.OnClientConnecting -= NetworkHandlers.OnClientConnecting;
            _network.OnClientConnected -= NetworkHandlers.OnClientConnected;
            _network.OnReceiveData -= NetworkHandlers.OnReceiveData;
            _network.OnClientDisconnecting -= NetworkHandlers.OnClientDisconnecting;
            _network.OnClientDisconnected -= NetworkHandlers.OnClientDisconnected;
        }

        public void Tick(TimeSpan timeSinceLastTick)
        {
            /* We don't actually need to do anything here yet */
        }

        public Guid ObjectGuid { get; private set; }
    }
}