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
        public static void CopyFilesRecursively(string src, string trg)
        {
            // Create all the directories
            foreach (string dirPath in Directory.GetDirectories(src, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(src, trg));
            }
            // Copy and overwrite files
            foreach (string newPath in Directory.GetFiles(src, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(src, trg), true);
            }
        }
    }
}
