using System;
using Hurricane.Shared.Objects;

namespace Hurricane.Shared.Logging
{
    public interface ILogManager : IHurricaneObject
    {
        ILogger GetLoggerByGuid(Guid guid);
        ILogger RegisterLogger(ILogger logger);
        void UnregisterLogger(Guid loggerType);
    }
}