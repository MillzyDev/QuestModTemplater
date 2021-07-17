using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuestModTemplater.Commands
{
    class Clear : ICommand
    {
        public string getDescription()
        {
            return "Clears the cloned mod-template-repository";
        }

        public string getName()
        {
            return "clear";
        }

        public void handle()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(appDataPath, @"QuestModTemplater\");
            Console.WriteLine("Checking if AppData directory exists...");
            if (!Directory.Exists(path)) 
            { 
                Console.WriteLine("AppData directory does not exist.");
                return;
            }

            var templatePath = Path.Combine(path, @"quest-mod-template\");
            Console.WriteLine("Checking if quest-mod-template directory exists...");
            if (!Directory.Exists(templatePath))
            {
                Console.WriteLine("quest-mod-template directory does not exist.");
                return;
            }

            Console.WriteLine("Purging quest-mod-template directory...");

            FileUtils.Remove.RemoveReadOnlyDir(Path.Combine(templatePath, @".git\"));
            Directory.Delete(templatePath, true);

            Console.WriteLine("Cleared quest-mod-template!");
        }
    }
}
