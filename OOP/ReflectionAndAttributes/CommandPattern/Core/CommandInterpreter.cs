using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string CommandPostfix = "Command";
        public string Read(string args)
        {
            string[] commandData = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string commandName = commandData[0] + CommandPostfix;
            string[] commandArgs = commandData.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();
            Type commandType = assembly.GetTypes()
                .FirstOrDefault(c => c.Name.ToLower() == commandName
                .ToLower());
            if (commandType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            ICommand commandInstance = (ICommand)Activator.CreateInstance(commandType);

            string result = commandInstance.Execute(commandArgs);
            return result;
        }
    }
}
