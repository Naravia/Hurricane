using System;
using System.IO;
using Hurricane.Shared.Objects;

namespace Hurricane.Shared.Logging
{
    public interface ILogger : IHurricaneObject
    {
        TextWriter Output { get; set; }

        Boolean LoggerEnabled { get; set; }

        Boolean TraceOutputEnabled { get; set; }
        Boolean DebugOutputEnabled { get; set; }
        Boolean InfoOutputEnabled { get; set; }
        Boolean WarningOutputEnabled { get; set; }
        Boolean ErrorOutputEnabled { get; set; }
        Boolean FatalOutputEnabled { get; set; }

        String WriteTrace(Guid sender, String line, params Object[] parameters);
        String WriteDebug(Guid sender, String line, params Object[] parameters);
        String WriteInfo(Guid sender, String line, params Object[] parameters);
        String WriteWarning(Guid sender, String line, params Object[] parameters);
        String WriteError(Guid sender, String line, params Object[] parameters);
        String WriteFatal(Guid sender, String line, params Object[] parameters);
    }
}
