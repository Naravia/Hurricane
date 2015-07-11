using System;
using System.Collections.Generic;
using System.Linq;
using Hurricane.Shared.Logging;

namespace Hurricane.Logging.HurricaneLogger
{
    public class LogManager : ILogManager
    {
        private readonly Dictionary<Guid, ILogger> _loggers = new Dictionary<Guid, ILogger>();

        public LogManager()
        {
            ObjectGuid = Guid.NewGuid();
        }

        public ILogger GetLoggerByGuid(Guid guid)
        {
            return _loggers.ContainsKey(guid) ? _loggers[guid] : null;
        }

        public ILogger RegisterLogger(ILogger logger)
        {
            _loggers.Add(key: logger.ObjectGuid, value: logger);
            return logger;
        }

        public Guid ObjectGuid { get; private set; }

        public void UnregisterLogger(Guid guid)
        {
            _loggers.Remove(guid);
        }
    }
}