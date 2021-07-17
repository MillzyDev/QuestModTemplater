using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace QuestModTemplater.Commands
{
    class Create : ICommand
    {
        string ICommand.getDescription()
        {
            return "Creates a new template from the downloaded template. If it doesn't exist, a new one will be downloaded";
        }

        string ICommand.getName()
        {
            return "create";
        }

        void ICommand.handle()
        {
            string execPath = Directory.GetCurrentDirectory();
            Console.WriteLine(execPath);

            // Testing paths
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var templatePath = Path.Combine(appDataPath, @"QuestModTemplater\quest-mod-template\");

            Console.WriteLine("Checking if quest-mod-template directory exists...");
            if (!Directory.Exists(templatePath))
            {
                Console.WriteLine("quest-mod-template directory missing.");
                Console.WriteLine("Calling Update.");
                // Calls update command
                Program.commands[3].handle();
            }


            // Collecting template values
            Console.WriteLine("\nEnter a value for \"id\":");
            string id = Console.ReadLine();

            Console.WriteLine("Enter a value for \"name\":");
            string name = Console.ReadLine();

            Console.WriteLine("Enter a value for \"description\":");
            string description = Console.ReadLine();

            Console.WriteLine("Enter a value for \"author\":");
            string author = Console.ReadLine();

            Console.WriteLine("Enter a value for \"ndkpath\":");
            string ndkpath = Console.ReadLine();

            // Copy files
            Console.WriteLine("\nCoppying Template to new destination...");
            FileUtils.Template.CopyFilesRecursively(new DirectoryInfo(Path.Combine(templatePath, @"template\")), new DirectoryInfo(execPath));
            System.Threading.Thread.Sleep(5000);

            // Replace values
            Console.WriteLine("Replacing template values...");
            FileUtils.Template.ReplaceTemplateValues(new DirectoryInfo(Path.Combine(templatePath, @"template\")), id, name, description, author, ndkpath);

            Console.WriteLine("Template created!");
        }
    }
}
