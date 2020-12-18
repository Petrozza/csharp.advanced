using SOLID.Enums;
using SOLID.Layouts;
using SOLID.Loggers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Appenders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, ILogFile logFile)
        {
            Layout = layout;
            LogFile = logFile;
        }
        public ILayout Layout { get; }
        public ILogFile LogFile { get; }
        public ReportLevel ReportLevel { get ; set; }

        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel >= ReportLevel)
            {
                LogFile.Write(string.Format(Layout.Format, dateTime, reportLevel, message));
            }
        }
    }
}
