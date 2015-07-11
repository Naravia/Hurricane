using System;
using System.Net;
using System.Threading;
using Hurricane.Components.HurricaneTicker;
using Hurricane.Components.Logon.LogonClient;
using Hurricane.Components.Logon.TBCPacketHandler;
using Hurricane.Logging.HurricaneLogger;
using Hurricane.Networking.HurricaneNetworker;
using Hurricane.Shared.Components.Logon;
using Hurricane.Shared.Components.Logon.Interfaces;
using Hurricane.Shared.Logging;
using Hurricane.Shared.Logging.Interfaces;
using Hurricane.Shared.Networking;
using Hurricane.Shared.Networking.Interfaces;
using Hurricane.Shared.Objects;
using Hurricane.Shared.Objects.Interfaces;
using HurricaneObjectManager;

namespace Hurricane.Binaries.LogonServer
{
    internal class Program
    {
        public static Guid MyGuid = Guid.NewGuid();

        private static void Main(String[] args)
        {
            var startupTime = DateTime.Now;

            // ReSharper disable SuggestVarOrType_SimpleTypes
            ILogManager logManager = new LogManager();
            var consoleLogger =
                logManager.RegisterLogger(logger: new Logger(sourceName: "LogonServer", output: Console.Out));
            IHurricaneObjectManager logonClientManager = new ObjectManager();
            INetworkInterface networkManager = new HurricaneNetworkInterface(bindAddress: IPAddress.Any, bindPort: 3724,
                log: consoleLogger);
            ILogonClientFactory logonClientFactory = new LogonClientFactory();
            IPacketFactory packetFactory = new PacketFactory();
            ILogonPacketFactory logonPacketFactory = new TBCLogonPacketFactory(log: consoleLogger);
            ILogonPacketHandler logonPacketHandler = new TBCPacketHandler(log: consoleLogger);

            var logonServer = new Components.Logon.LogonServer.LogonServer(log: consoleLogger, network: networkManager,
                objectManager: logonClientManager, factory: logonClientFactory, packetFactory: packetFactory, logonPacketFactory: logonPacketFactory,
                logonPacketHandler: logonPacketHandler);
            logonServer.Initialise();
            logonServer.Boot();

            var logonTicker = new HurricaneTicker(component: logonServer, log: consoleLogger)
            {
                Interval = TimeSpan.FromMilliseconds(value: 15),
                Enabled = true
            };

            //for (var i = 0; i < 30; ++i)
            //{
            //    consoleLogger.WriteInfo(MyGuid, "Ticks: Last[{0}] Average[{1}] Slowest[{2}] Fastest[{3}] Count[{4}]",
            //        logonTicker.LastTick.TotalMilliseconds, logonTicker.AverageTick.TotalMilliseconds,
            //        logonTicker.SlowestTick.TotalMilliseconds, logonTicker.FastestTick.TotalMilliseconds,
            //        logonTicker.TickCount);
            //    Thread.Sleep(1000);
            //}

            Console.ReadLine();

            var finishTime = DateTime.Now;

            var runTime = finishTime - startupTime;
            consoleLogger.WriteInfo(MyGuid, "LogonServer ran successfully! Runtime: {0}d{1}h{2}m{3}s{4}ms", runTime.Days,
                runTime.Hours, runTime.Minutes, runTime.Seconds, runTime.Milliseconds);

            var shutdownTime = 5;
            consoleLogger.WriteInfo(MyGuid, "Shutdown in {0} seconds", shutdownTime);
            Thread.Sleep(shutdownTime*1000);
            // ReSharper restore SuggestVarOrType_SimpleTypes
        }
    }
}