using System;
using System.Collections.Generic;
using System.Linq;
using Hurricane.Shared.Logging;

namespace Hurricane.Logging.HurricaneLogger
{
    public class LogManager : ILogManager
    {
        private readonly Dictionary<LoggerTypeEnum, ILogger> _loggers = new Dictionary<LoggerTypeEnum, ILogger>();

        public LogManager()
        {
            LogManagerGuid = Guid.NewGuid();
        }

        public Guid LogManagerGuid { get; private set; }

        public ILogger GetLoggerByType(LoggerTypeEnum loggerType)
        {
            return _loggers.ContainsKey(loggerType) ? _loggers[loggerType] : null;
        }

        public ILogger GetLoggerByGuid(Guid guid)
        {
            return (from logger in _loggers
                where logger.Value.LoggerGuid == guid
                select logger.Value).FirstOrDefault();
        }

        public ILogger RegisterLogger(LoggerTypeEnum loggerType, ILogger logger)
        {
            _loggers.Add(key: loggerType, value: logger);
            return logger;
        }

        public void UnregisterLogger(LoggerTypeEnum loggerType)
        {
            _loggers.Remove(loggerType);
        }
    }
}