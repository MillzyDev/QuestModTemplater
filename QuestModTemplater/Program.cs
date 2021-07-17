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
            if (args.Length == 0)
            {
                // Call help command
                Console.WriteLine("Command not found...");
                commands[2].handle();
            }
            // Check if command is valid command
            foreach (ICommand command in commands)
            {
                if (command.getName() == args[0])
                {
                    // Execute command
                    command.handle();
                    return;
                }
                // Call help command
                Console.WriteLine("Command not found...");
                commands[2].handle();
            }
        }
    }
}
