using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuestModTemplater.FileUtils
{
    class Template
    {
        public static void CopyFilesRecursively(DirectoryInfo src, DirectoryInfo trg)
        {
            foreach (DirectoryInfo dir in src.GetDirectories())
            {
               // Coppies directory to new location
                CopyFilesRecursively(dir, trg.CreateSubdirectory(dir.Name));
            }
            foreach (FileInfo file in src.GetFiles())
            {
                // Coppies file to new location
                file.CopyTo(Path.Combine(trg.FullName, file.Name));
            }
        }

        public static void ReplaceTemplateValues(DirectoryInfo dir, string id, string name, string desc, string author, string ndkpath) 
        {
            // Calls self on subdirectories found
            foreach (DirectoryInfo subdir in dir.GetDirectories())
            {
                ReplaceTemplateValues(subdir, id, name, desc, author, ndkpath);
            }
            // Replaces template values in files with ones provided
            foreach (FileInfo file in dir.GetFiles())
            {
                string text = File.ReadAllText(file.FullName);

                text.Replace("#{id}", id);
                text.Replace("#{name}", name);
                text.Replace("#{description}", desc);
                text.Replace("#{author}", author);
                text.Replace("#{ndkpath}", ndkpath);

                File.WriteAllText(file.FullName, text);
            }
        }
    }
}
