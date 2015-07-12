using System;
using System.Net;
using Hurricane.Logging.DevLogger;
using Hurricane.Networking.DevNetworker;
using Hurricane.Networking.IPC.DevIPCHandler;
using Hurricane.Networking.IPC.DevIPCInterface.TCP;

namespace Hurricane.Binaries.RoutingServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var myGuid = Guid.NewGuid();

            var log = new Logger(sourceName: "RoutingServer", output: Console.Out);
            new LogManager().RegisterLogger(log);

            var networkInterface = new HurricaneNetworkInterface(IPAddress.Any, 8085, log);
            var ipcInterface = new IPCInterface(log: log, network: networkInterface, serialiser: null);
            var ipcHandler = new IPCHandler(ipcInterface, null, log, myGuid);

            var router = new Components.Routing.DevRoutingServer.RoutingServer(log: log, ipcHandler: ipcHandler, ipcInterface: ipcInterface);
        }
    }
}
