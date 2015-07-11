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

        String WriteTrace(String line, params Object[] parameters);
        String WriteDebug(String line, params Object[] parameters);
        String WriteInfo(String line, params Object[] parameters);
        String WriteWarning(String line, params Object[] parameters);
        String WriteError(String line, params Object[] parameters);
        String WriteFatal(String line, params Object[] parameters);
    }
}
