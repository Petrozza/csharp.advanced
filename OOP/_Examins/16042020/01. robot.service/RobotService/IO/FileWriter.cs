using RobotService.IO.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RobotService.IO
{
    public class FileWriter : IWriter
    {
        public void Write(string message)
        {
            File.AppendAllText("../../../output.txt", message);
        }

        public void WriteLine(string message)
        {
            throw new NotImplementedException();
        }
    }
}
