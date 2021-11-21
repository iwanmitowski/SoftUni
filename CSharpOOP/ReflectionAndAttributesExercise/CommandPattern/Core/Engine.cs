using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core
{
    class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;
        public Engine(ICommandInterpreter command)
        {
            commandInterpreter = command;
        }

        public void Run()
        {
            var result = commandInterpreter.Read(Console.ReadLine());

            if (result == null)
            {
                Environment.Exit(0);
            }

            Console.WriteLine(result);
        }
    }
}
