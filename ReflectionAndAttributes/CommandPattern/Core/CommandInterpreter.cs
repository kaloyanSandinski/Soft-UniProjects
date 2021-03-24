using CommandPattern.Core.Contracts;
using System;
using System.Data;
using System.Reflection;
using System.Linq;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string commandPostfix = "Command";
        public string Read(string args)
        {
            var inputData = args.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string cmdName = inputData[0]+commandPostfix;
            var cmdArgs = inputData.Skip(1).ToArray();

            Assembly assemblly = Assembly.GetCallingAssembly();
            Type commandType = assemblly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == cmdName.ToLower());

            if (commandType==null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            ICommand command = (ICommand)Activator.CreateInstance(commandType);
            string result = command.Execute(cmdArgs);
            return result;
        }
    }
}
