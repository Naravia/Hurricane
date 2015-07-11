using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Hurricane.Shared.Logging
{
    /// <summary>
    /// Holds a collection of loggers to enable easy writing to multiple loggers at once (e.g. file and cli loggers)
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedMember.Local")]
    public class LoggerCollection
    {
        private readonly List<ILogger> _loggers = new List<ILogger>();

        public LoggerCollection(params ILogger[] loggers)
        {
            foreach(var logger in loggers)
                _loggers.Add(logger);
        }

        public void WriteTrace(String line, params Object[] parameters)
        {
            foreach (var logger in _loggers)
                logger.WriteTrace(line, parameters);
        }

        public void WriteDebug(String line, params Object[] parameters)
        {
            foreach (var logger in _loggers)
                logger.WriteDebug(line, parameters);
        }

        public void WriteInfo(String line, params Object[] parameters)
        {
            foreach (var logger in _loggers)
                logger.WriteInfo(line, parameters);
        }

        public void WriteWarning(String line, params Object[] parameters)
        {
            foreach (var logger in _loggers)
                logger.WriteWarning(line, parameters);
        }

        public void WriteError(String line, params Object[] parameters)
        {
            foreach (var logger in _loggers)
                logger.WriteError(line, parameters);
        }

        public void WriteFatal(String line, params Object[] parameters)
        {
            foreach (var logger in _loggers)
                logger.WriteFatal(line, parameters);
        }
    }
}