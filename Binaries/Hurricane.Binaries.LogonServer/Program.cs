using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using Hurricane.Logging.HurricaneLogger;
using Hurricane.Networking.HurricaneNetworker;
using Hurricane.Shared.Logging;

namespace Hurricane.Binaries.LogonServer
{
    class Program
    {
        static void Main(String[] args)
        {
            var logManager = new LogManager();

            /* File logging not supported yet, so create a dummy logger */
            var fileLogger = logManager.RegisterLogger(LoggerTypeEnum.FileLogger, new Logger(sourceName: "LogonServer", output: TextWriter.Null, loggerEnabled: false));
            var consoleLogger = logManager.RegisterLogger(LoggerTypeEnum.CLILogger, new Logger(sourceName: "LogonServer", output: Console.Out));

            var logCollection = new LoggerCollection(fileLogger, consoleLogger);

            var networkManager = new HurricaneNetworkInterface(IPAddress.Any, 3724, logCollection);

            /* Config not supported yet */
            //consoleLogger.TraceOutputEnabled = false;

            consoleLogger.WriteTrace("fileLogger GUID: {0}", fileLogger.LoggerGuid);
            consoleLogger.WriteTrace("consoleLogger GUID: {0}", consoleLogger.LoggerGuid);

            /* Just a test, not a final feature */
            consoleLogger.WriteTrace(String.Empty);
            consoleLogger.WriteTrace("Look");
            consoleLogger.WriteDebug("at");
            consoleLogger.WriteInfo("the");
            consoleLogger.WriteWarning("pretty");
            consoleLogger.WriteError("tag");
            consoleLogger.WriteFatal("alignment");

            consoleLogger.WriteTrace("This is a really long\nlog entry\nspanning multiple lines of output and\nbeing used to demonstrate logger functionality");

            var startupTime = DateTime.Now;

            var logonServer = new Hurricane.Components.LogonServer.LogonServer(logCollection, networkManager);
            logonServer.Initialise();

            var finishTime = DateTime.Now;

            var runTime = finishTime - startupTime;
            logManager.GetLoggerByType(LoggerTypeEnum.CLILogger).WriteInfo("LogonServer ran successfully! Runtime: {0}d{1}h{2}m{3}s{4}ms", runTime.Days, runTime.Hours, runTime.Minutes, runTime.Seconds, runTime.Milliseconds);

            var shutdownTime = 5;
            consoleLogger.WriteInfo("Shutdown in {0} seconds", shutdownTime);
            Thread.Sleep(shutdownTime * 1000);
        }
    }
}
