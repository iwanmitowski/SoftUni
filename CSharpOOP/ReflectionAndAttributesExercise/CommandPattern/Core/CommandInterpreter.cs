using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tokens = args.Split();

            string type = tokens[0] + "Command";
            Type commandType = Assembly.GetCallingAssembly().GetTypes().Where(x => x.Name.StartsWith(type)).FirstOrDefault();

            ICommand command = Activator.CreateInstance(commandType) as ICommand;

            var result = command.Execute(tokens);

            return result;
        }
    }
}
