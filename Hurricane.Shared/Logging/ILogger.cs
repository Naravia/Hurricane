using System;

namespace Hurricane.Shared.Logging
{
    public interface ILogger
    {
        Guid GetLoggerGuid();

        String WriteTrace(String line, params Object[] parameters);
        String WriteDebug(String line, params Object[] parameters);
        String WriteInfo(String line, params Object[] parameters);
        String WriteWarning(String line, params Object[] parameters);
        String WriteError(String line, params Object[] parameters);
        String WriteFatal(String line, params Object[] parameters);

        void EnableTrace();
        void EnableDebug();
        void EnableInfo();
        void EnableWarning();
        void EnableError();
        void EnableFatal();

        void DisableTrace();
        void DisableDebug();
        void DisableInfo();
        void DisableWarning();
        void DisableError();
        void DisableFatal();
    }
}
