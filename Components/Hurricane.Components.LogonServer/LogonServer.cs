using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hurricane.Shared.Logging;
using Hurricane.Shared.Networking;

namespace Hurricane.Components.LogonServer
{
    public class LogonServer
    {
        private LoggerCollection _log;
        private INetworkInterface _network;

        public LogonServer(LoggerCollection log, INetworkInterface network)
        {
            _log = log;
            _network = network;
        }

        public bool Initialise()
        {
            _log.WriteInfo("Starting up");
            _network.Startup();
            return true;
        }
    }
}
