using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Loggers
{
    public interface ILogFile
    {
        void Write(string message);
        int Size { get; }
    }
}
