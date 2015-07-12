using System;
using System.Collections.Generic;
using Hurricane.Shared.Logging.Interfaces;

namespace Hurricane.Logging.DevLogger
{
    public class LogManager : ILogManager
    {
        private readonly Dictionary<Guid, ILogger> _loggers = new Dictionary<Guid, ILogger>();

        public LogManager()
        {
            this.ObjectGuid = Guid.NewGuid();
        }

        public ILogger GetLoggerByGuid(Guid guid)
        {
            return this._loggers.ContainsKey(guid) ? this._loggers[guid] : null;
        }

        public ILogger RegisterLogger(ILogger logger)
        {
            this._loggers.Add(key: logger.ObjectGuid, value: logger);
            return logger;
        }

        public Guid ObjectGuid { get; private set; }

        public void UnregisterLogger(Guid guid)
        {
            this._loggers.Remove(guid);
        }
    }
}