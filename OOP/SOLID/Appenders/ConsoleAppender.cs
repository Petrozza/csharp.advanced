using SOLID.Enums;
using SOLID.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            Layout = layout;
        }
        public ILayout Layout { get; }
        public ReportLevel ReportLevel { get; set; }

        public void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if (reportLevel > this.ReportLevel)
            {
                Console.WriteLine(Layout.Format, dateTime, reportLevel, message);
            }
        }
    }
}
