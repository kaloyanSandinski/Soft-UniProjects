using System;
using System.Collections.Generic;
using System.Text;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models
{
    class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter; 
        public Engine(ICommandInterpreter commnad)
        {
            this.commandInterpreter = commnad;
        }
        public void Run()
        {
            while (true)
            {
                string args = Console.ReadLine();

                try
                {
                    string result = this.commandInterpreter.Read(args);
                    Console.WriteLine(result);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
