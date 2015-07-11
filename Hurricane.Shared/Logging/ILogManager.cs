using System;
using Hurricane.Shared.Objects;

namespace Hurricane.Shared.Logging
{
    public interface ILogManager : IHurricaneObject
    {
        ILogger GetLoggerByType(LoggerTypeEnum loggerType);
        ILogger GetLoggerByGuid(Guid guid);
    }
}