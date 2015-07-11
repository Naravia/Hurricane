using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hurricane.Shared.Logging;

namespace Hurricane.Logging.HurricaneLogger
{
    public static class LogManager
    {
        private static Dictionary<Guid, Logger> _loggers = new Dictionary<Guid, Logger>();

        public static ILogger RegisterLogger(String name, TextWriter output, Boolean traceEnabled = true,
            Boolean debugEnabled = true, Boolean infoEnabled = true, Boolean warningEnabled = true,
            Boolean errorEnabled = true, Boolean fatalEnabled = true)
        {
            var guid = Guid.NewGuid();
            var logger = new Logger(name: name, guid: guid, output: output,
                traceEnabled: traceEnabled, debugEnabled: debugEnabled, infoEnabled: infoEnabled,
                warningEnabled: warningEnabled, errorEnabled: errorEnabled, fatalEnabled: fatalEnabled);
            
            _loggers.Add(key: guid, value: logger);
            return logger;
        }

        public static ILogger GetLogger(Guid loggerGuid)
        {
            if (_loggers.ContainsKey(loggerGuid))
                return _loggers[loggerGuid];

            throw new KeyNotFoundException(String.Format("Logged with GUID [{0}] has not been registered (and probably doesn't exist)", loggerGuid));
        }
    }
}