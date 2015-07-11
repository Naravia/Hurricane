using System;
using System.IO;
using System.Threading;
using Hurricane.Logging.HurricaneLogger;

namespace Hurricane.Binaries.LogonServer
{
    class Program
    {
        static void Main(String[] args)
        {
            /* File logging not supported yet, so create a dummy logger */
            var fileLogger = LogManager.RegisterLogger(name: "LogonServer", output: TextWriter.Null, traceEnabled: false,
                debugEnabled: false, infoEnabled: false, warningEnabled: false,
                errorEnabled: false, fatalEnabled: false);
            var consoleLogger = LogManager.RegisterLogger(name: "LogonServer", output: Console.Out);

            /* Config not supported yet */
            consoleLogger.DisableTrace();

            var startupTime = DateTime.Now;

            var logonServer = new Hurricane.Components.LogonServer.LogonServer(feedbackLogger: consoleLogger, fileLogger: fileLogger);
            logonServer.Initialise();

            var finishTime = DateTime.Now;

            var runTime = finishTime - startupTime;
            consoleLogger.WriteInfo("LogonServer ran successfully! Runtime: {0}d{1}h{2}m{3}s{4}ms", runTime.Days, runTime.Hours, runTime.Minutes, runTime.Seconds, runTime.Milliseconds);

            var shutdownTime = 5;
            consoleLogger.WriteInfo("Shutdown in {0} seconds", shutdownTime);
            Thread.Sleep(shutdownTime * 1000);
        }
    }
}
