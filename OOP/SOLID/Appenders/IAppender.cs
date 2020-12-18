using SOLID.Enums;
using SOLID.Layouts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Appenders
{
    public interface IAppender
    {
        public ILayout Layout { get; }
        public ReportLevel ReportLevel { get; set; }

        void Append(string dateTime, ReportLevel logLevel, string message);
    }
}
