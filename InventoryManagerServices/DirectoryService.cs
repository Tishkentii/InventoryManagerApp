using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagerModel.DTOs;

namespace InventoryManagerServices
{
    internal class DirectoryService
    {
        internal static string SaveToFile(string csvText, string relativePath, string fileName)
        {
            var saveDirectory = $@"{Directory.GetCurrentDirectory()}\{relativePath}";
            if (!Directory.Exists(saveDirectory))
                Directory.CreateDirectory(saveDirectory);

            var fullPath = $@"{saveDirectory}{fileName}";
            File.WriteAllText(fullPath, csvText);
            return fullPath;
        }

        internal static void OpenFile(string path)
        {
            Process.Start(path);
        }

    }
}
