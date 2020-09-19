using CommandPattern.Core.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";

        public string Read(string args)
        {
            var commandInfo = args
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var commandName = commandInfo[0] + COMMAND_POSTFIX;

            var commandArgs = commandInfo.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();
            Type[] types = assembly.GetTypes();
            Type typeToCreate = types.FirstOrDefault(t => t.Name == commandName);

            Object instance = Activator.CreateInstance(typeToCreate);
            ICommand command = (ICommand)instance;

            string result = command.Execute(commandArgs);

            return result;
        }
    }
}
