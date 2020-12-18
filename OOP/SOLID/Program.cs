using SOLID.Appenders;
using SOLID.Enums;
using SOLID.Layouts;
using SOLID.Loggers;
using System;

namespace SOLID
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var simpleLayout = new SimpleLayout();
            var logFile = new LogFile();
            var fileAppender = new FileAppender(simpleLayout, logFile);
            fileAppender.ReportLevel = ReportLevel.ERROR;

            var logger = new Logger(fileAppender);

            //logger.Info("3/31/2015 5:33:07 PM", "Everything seems fine");
            //logger.Warning("3/31/2015 5:33:07 PM", "Warning: ping is too high - disconnect imminent");
            logger.Error("3/31/2015 5:33:07 PM", "Error parsing request");
            //logger.Critical("3/31/2015 5:33:07 PM", "No connection string found in App.config");
            //logger.Fatal("3/31/2015 5:33:07 PM", "mscorlib.dll does not respond");
            Console.WriteLine((fileAppender).LogFile.Size);

        }
    }
}
