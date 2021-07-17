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
            foreach (var subdir in Directory.EnumerateDirectories(dir))
            {
                RemoveReadOnlyDir(subdir);
            }
            foreach (var file in Directory.EnumerateFiles(dir))
            {
                var fileInfo = new FileInfo(file);
                fileInfo.Attributes = FileAttributes.Normal;
                fileInfo.Delete();
            }
            Directory.Delete(dir);
        }
    }
}
