using System;
using System.IO;
using Hurricane.Shared.Logging;

namespace Hurricane.Logging.HurricaneLogger
{
    internal class Logger : ILogger
    {
        private readonly Guid _guid;
        private readonly TextWriter _output;
        private readonly String _name;

        private Boolean _traceEnabled;
        private Boolean _debugEnabled;
        private Boolean _infoEnabled;
        private Boolean _warningEnabled;
        private Boolean _errorEnabled;
        private Boolean _fatalEnabled;

        public Logger(String name, Guid guid, TextWriter output, Boolean traceEnabled = true,
            Boolean debugEnabled = true, Boolean infoEnabled = true, Boolean warningEnabled = true,
            Boolean errorEnabled = true, Boolean fatalEnabled = true)
        {
            _name = name;
            _guid = guid;
            _output = output;
            _traceEnabled = traceEnabled;
            _debugEnabled = debugEnabled;
            _infoEnabled = infoEnabled;
            _warningEnabled = warningEnabled;
            _errorEnabled = errorEnabled;
            _fatalEnabled = fatalEnabled;
        }

        public Guid GetLoggerGuid()
        {
            return _guid;
        }

        private String Parse(String source, String line, params Object[] parameters)
        {
            var computedLine = String.Format(line, parameters);
            return String.Format("{0}/{1}: {2}", _name, source, computedLine);
        }

        public String WriteTrace(String line, params Object[] parameters)
        {
            if (!_traceEnabled) return String.Empty;

            var text = Parse("Trace", line, parameters);
            _output.WriteLine(text);
            return text;
        }

        public String WriteDebug(String line, params Object[] parameters)
        {
            if (!_debugEnabled) return String.Empty;

            var text = Parse("Debug", line, parameters);
            _output.WriteLine(text);
            return text;
        }

        public String WriteInfo(String line, params Object[] parameters)
        {
            if (!_infoEnabled) return String.Empty;

            var text = Parse("Info", line, parameters);
            _output.WriteLine(text);
            return text;
        }

        public String WriteWarning(String line, params Object[] parameters)
        {
            if (!_warningEnabled) return String.Empty;

            var text = Parse("Warning", line, parameters);
            _output.WriteLine(text);
            return text;
        }

        public String WriteError(String line, params Object[] parameters)
        {
            if (!_errorEnabled) return String.Empty;

            var text = Parse("Error", line, parameters);
            _output.WriteLine(text);
            return text;
        }

        public String WriteFatal(String line, params Object[] parameters)
        {
            if (!_fatalEnabled) return String.Empty;

            var text = Parse("Fatal", line, parameters);
            _output.WriteLine(text);
            return text;
        }

        public void EnableTrace()
        {
            _traceEnabled = true;
        }

        public void EnableDebug()
        {
            _debugEnabled = true;
        }

        public void EnableInfo()
        {
            _infoEnabled = true;
        }

        public void EnableWarning()
        {
            _warningEnabled = true;
        }

        public void EnableError()
        {
            _errorEnabled = true;
        }

        public void EnableFatal()
        {
            _fatalEnabled = true;
        }

        public void DisableTrace()
        {
            _traceEnabled = false;
        }

        public void DisableDebug()
        {
            _debugEnabled = false;
        }

        public void DisableInfo()
        {
            _infoEnabled = false;
        }

        public void DisableWarning()
        {
            _warningEnabled = false;
        }

        public void DisableError()
        {
            _errorEnabled = false;
        }

        public void DisableFatal()
        {
            _fatalEnabled = false;
        }
    }
}
