using System;
using System.IO;
using Hurricane.Shared.Logging.Interfaces;

namespace Hurricane.Logging.HurricaneLogger
{
    public class Logger : ILogger
    {
        private readonly String _sourceName;

        public Logger(String sourceName, TextWriter output = null, Boolean traceEnabled = true,
            Boolean debugEnabled = true, Boolean infoEnabled = true, Boolean warningEnabled = true,
            Boolean errorEnabled = true, Boolean fatalEnabled = true, Boolean loggerEnabled = true)
        {
            this.ObjectGuid = Guid.NewGuid();

            this._sourceName = sourceName;

            /* If null, replace with TextWriter.Null (which can be written to) */
            this.Output = output ?? TextWriter.Null;

            this.LoggerEnabled = loggerEnabled;
            this.TraceOutputEnabled = traceEnabled;
            this.DebugOutputEnabled = debugEnabled;
            this.InfoOutputEnabled = infoEnabled;
            this.WarningOutputEnabled = warningEnabled;
            this.ErrorOutputEnabled = errorEnabled;
            this.FatalOutputEnabled = fatalEnabled;
        }

        public TextWriter Output { get; set; }
        public Boolean LoggerEnabled { get; set; }
        public Boolean TraceOutputEnabled { get; set; }
        public Boolean DebugOutputEnabled { get; set; }
        public Boolean InfoOutputEnabled { get; set; }
        public Boolean WarningOutputEnabled { get; set; }
        public Boolean ErrorOutputEnabled { get; set; }
        public Boolean FatalOutputEnabled { get; set; }

        public String WriteTrace(Guid sender, String line, params Object[] parameters)
        {
            if (!this.TraceOutputEnabled) return String.Empty;

            var text = this.Parse("T", line, parameters);
            this.Output.WriteLine(text);
            return text;
        }

        public String WriteDebug(Guid sender, String line, params Object[] parameters)
        {
            if (!this.DebugOutputEnabled) return String.Empty;

            var text = this.Parse("D", line, parameters);
            this.Output.WriteLine(text);
            return text;
        }

        public String WriteInfo(Guid sender, String line, params Object[] parameters)
        {
            if (!this.InfoOutputEnabled) return String.Empty;

            var text = this.Parse("I", line, parameters);
            this.Output.WriteLine(text);
            return text;
        }

        public String WriteWarning(Guid sender, String line, params Object[] parameters)
        {
            if (!this.WarningOutputEnabled) return String.Empty;

            var text = this.Parse("W", line, parameters);
            this.Output.WriteLine(text);
            return text;
        }

        public String WriteError(Guid sender, String line, params Object[] parameters)
        {
            if (!this.ErrorOutputEnabled) return String.Empty;

            var text = this.Parse("E", line, parameters);
            this.Output.WriteLine(text);
            return text;
        }

        public String WriteFatal(Guid sender, String line, params Object[] parameters)
        {
            if (!this.FatalOutputEnabled) return String.Empty;

            var text = this.Parse("F", line, parameters);
            this.Output.WriteLine(text);
            return text;
        }

        public Guid ObjectGuid { get; private set; }

        private String Parse(String source, String line, params Object[] parameters)
        {
            var tag = String.Format("[{0}]", source);
            var computedLine = String.Format(line, parameters);
            var computedLineSplitByNewlines = computedLine.Split(new[] {"\r\n", "\n"}, StringSplitOptions.None);

            var finalLine = String.Format("{0} {1}", tag, computedLineSplitByNewlines[0]);

            if (computedLineSplitByNewlines.Length > 1)
            {
                for (var i = 1; i < computedLineSplitByNewlines.Length; ++i)
                {
                    finalLine += String.Format("{0}... {1}", Environment.NewLine, computedLineSplitByNewlines[i]);
                }
            }

            //return String.Format("{0} {1}", tag, computedLine);
            return finalLine;
        }
    }
}