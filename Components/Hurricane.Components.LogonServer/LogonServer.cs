using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hurricane.Shared.Logging;

namespace Hurricane.Components.LogonServer
{
    public class LogonServer
    {
        private ILogger _feedbackLogger;
        private ILogger _fileLogger;

        public LogonServer(ILogger feedbackLogger, ILogger fileLogger)
        {
            _feedbackLogger = feedbackLogger;
            _fileLogger = fileLogger;
        }

        public bool Initialise()
        {
            _feedbackLogger.WriteInfo("Starting up");
            _fileLogger.WriteInfo("Starting up");
            return true;
        }
    }
}
