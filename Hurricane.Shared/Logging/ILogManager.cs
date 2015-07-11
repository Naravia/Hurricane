using System;

namespace Hurricane.Shared.Logging
{
    public interface ILogManager
    {
        Guid LogManagerGuid { get; }

        ILogger GetLoggerByType(LoggerTypeEnum loggerType);
        ILogger GetLoggerByGuid(Guid guid);
    }
}