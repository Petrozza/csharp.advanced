using SOLID.Appenders;
using SOLID.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Loggers
{
    public class Logger : ILogger
    {
        private IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            Appenders = appenders;
        }
        public IAppender[] Appenders 
        {
            get
            {
                return this.appenders;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Appenders), "value cannot be null");
                }
                this.appenders = value;
            }
        }

        public void Error(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.ERROR, message);
        }

        

        public void Info(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Info, message);
        }

        public void Critical(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Critical, message);
        }

        public void Fatal(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Fatal, message);
        }

        public void Warning(string dateTime, string message)
        {
            Append(dateTime, ReportLevel.Warning, message);
        }

        private void Append(string dateTime, ReportLevel error, string message)
        {
            foreach (var appender in Appenders)
            {
                appender.Append(dateTime, error, message);
            }
        }
    }
}
