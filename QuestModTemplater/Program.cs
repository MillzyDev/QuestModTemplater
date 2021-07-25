using System;
using System.Collections.Generic;

using QuestModTemplater;

namespace QuestModTemplater
{
    class Program
    {
        public static List<ICommand> commands = new List<ICommand>
        {
            new Commands.Clear(),
            new Commands.Create(),
            new Commands.Help(),
            new Commands.Update()
        };

        static void Main(string[] args)
        {
            try
            {
                foreach (ICommand command in commands)
                {
                    if (command.getName().ToLower() == args[0].ToLower())
                    {
                        // Execute command
                        command.handle();
                        return;
                    }
                    else throw new Exception();
                }
            } catch (Exception)
            {
                // Call help command
                Console.WriteLine("Command not found...");
                commands[2].handle();
            }
        }
    }
}
