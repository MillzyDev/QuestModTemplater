using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using LibGit2Sharp;

using QuestModTemplater;

namespace QuestModTemplater.Commands
{
    class Update : ICommand
    {
        string ICommand.getDescription()
        {
            return "Updates the downloaded template, or redownloads it.";
        }

        string ICommand.getName()
        {
            return "update";
        }

        void ICommand.handle()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(appDataPath, @"QuestModTemplater\");
            Console.WriteLine("Checking if AppData directory exists...");
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            var templatePath = Path.Combine(path, @"quest-mod-template\");
            Console.WriteLine("Checking if quest-mod-template directory exists...");
            if (!Directory.Exists(templatePath))
            {
                Console.WriteLine("Creating quest-mod-template directory...");
                Directory.CreateDirectory(templatePath);
            } else
            {
                Console.WriteLine("Calling Clear Command!");

                Program.commands[0].handle();
            }

            Console.WriteLine($"Cloning repository from {BaseValues.baseUrl}...");
                Repository.Clone(BaseValues.baseUrl, templatePath);

            Console.WriteLine("Cloned quest-mod-template!");

            Console.WriteLine("Updated quest-mod-template!");
        }
    }
}
