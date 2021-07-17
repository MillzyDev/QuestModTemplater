using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QuestModTemplater.FileUtils
{
    class Remove
    {
        public static void RemoveReadOnlyDir(string dir) 
        {
            try
            {
                foreach (var subdir in Directory.EnumerateDirectories(dir))
                {
                    // Call self on subdirs
                    RemoveReadOnlyDir(subdir);
                }
                foreach (var file in Directory.EnumerateFiles(dir))
                {
                    // Modify file attributes
                    var fileInfo = new FileInfo(file);
                    fileInfo.Attributes = FileAttributes.Normal;
                    fileInfo.Delete();
                }
                Directory.Delete(dir);
            } catch(DirectoryNotFoundException)
            {
                Console.WriteLine($"Unable to delete {dir}...");
            }
        }
    }
}
