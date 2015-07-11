using System;
using Hurricane.Shared.Objects.Interfaces;

namespace Hurricane.Shared.Logging.Interfaces
{
    public interface ILogManager : IHurricaneObject
    {
        ILogger GetLoggerByGuid(Guid guid);
        ILogger RegisterLogger(ILogger logger);
        void UnregisterLogger(Guid loggerType);
    }
}