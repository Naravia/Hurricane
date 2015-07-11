using System;
using System.IO;
using Hurricane.Shared.Logging;

namespace Hurricane.Logging.HurricaneLogger
{
    public class Logger : ILogger
    {
        public Guid LoggerGuid { get; private set; }
        public TextWriter Output { get; set; }
        public Boolean LoggerEnabled { get; set; }

        public Boolean TraceOutputEnabled { get; set; }
        public Boolean DebugOutputEnabled { get; set; }
        public Boolean InfoOutputEnabled { get; set; }
        public Boolean WarningOutputEnabled { get; set; }
        public Boolean ErrorOutputEnabled { get; set; }
        public Boolean FatalOutputEnabled { get; set; }
        
        private readonly String _sourceName;

        public Logger(String sourceName, TextWriter output = null, Boolean traceEnabled = true,
            Boolean debugEnabled = true, Boolean infoEnabled = true, Boolean warningEnabled = true,
            Boolean errorEnabled = true, Boolean fatalEnabled = true, Boolean loggerEnabled = true)
        {
            LoggerGuid = Guid.NewGuid();

            _sourceName = sourceName;

            /* If null, replace with TextWriter.Null (which can be written to) */
            Output = output ?? TextWriter.Null;

            LoggerEnabled = loggerEnabled;
            TraceOutputEnabled = traceEnabled;
            DebugOutputEnabled = debugEnabled;
            InfoOutputEnabled = infoEnabled;
            WarningOutputEnabled = warningEnabled;
            ErrorOutputEnabled = errorEnabled;
            FatalOutputEnabled = fatalEnabled;
        }

        private String Parse(String source, String line, params Object[] parameters)
        {
            var computedLine = String.Format(line, parameters);
            return String.Format("[{0}]: {1,10}", source, computedLine);
        }

        public String WriteTrace(String line, params Object[] parameters)
        {
            if (!TraceOutputEnabled) return String.Empty;

            var text = Parse("Trace", line, parameters);
            Output.WriteLine(text);
            return text;
        }

        public String WriteDebug(String line, params Object[] parameters)
        {
            if (!DebugOutputEnabled) return String.Empty;

            var text = Parse("Debug", line, parameters);
            Output.WriteLine(text);
            return text;
        }

        public String WriteInfo(String line, params Object[] parameters)
        {
            if (!InfoOutputEnabled) return String.Empty;

            var text = Parse("Info", line, parameters);
            Output.WriteLine(text);
            return text;
        }

        public String WriteWarning(String line, params Object[] parameters)
        {
            if (!WarningOutputEnabled) return String.Empty;

            var text = Parse("Warning", line, parameters);
            Output.WriteLine(text);
            return text;
        }

        public String WriteError(String line, params Object[] parameters)
        {
            if (!ErrorOutputEnabled) return String.Empty;

            var text = Parse("Error", line, parameters);
            Output.WriteLine(text);
            return text;
        }

        public String WriteFatal(String line, params Object[] parameters)
        {
            if (!FatalOutputEnabled) return String.Empty;

            var text = Parse("Fatal", line, parameters);
            Output.WriteLine(text);
            return text;
        }
    }
}
