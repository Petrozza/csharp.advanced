﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SOLID.Loggers
{
    public class LogFile : ILogFile
    {
        private const string LogFilePath = "../../../log.txt";
        public int Size => File.ReadAllText(LogFilePath)
            .Where(c => char.IsLetter(c)).Sum(x => x);

        public void Write(string message)
        {
            
            File.AppendAllText(LogFilePath, message + Environment.NewLine);
        }
    }
}
