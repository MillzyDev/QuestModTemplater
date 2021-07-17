using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestModTemplater.Commands
{
    class Help : ICommand
    {
        public string getDescription()
        {
            return "Displays a list of commands and their purposes.";
        }

        public string getName()
        {
            return "help";
        }

        public void handle()
        {
            foreach (ICommand command in Program.commands)
            {
                Console.WriteLine($"{command.getName()} - {command.getDescription()}");
            }
        }
    }
}
