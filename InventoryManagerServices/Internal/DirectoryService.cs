using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagerModel.DTOs;

namespace InventoryManagerServices.Internal
{
    internal class DirectoryService
    {
        internal static string DestinationPath => $@"{Directory.GetCurrentDirectory()}\Spravki\";

        internal static string SaveToFile(string csvText, string fileName)
        {
            if (!Directory.Exists(DestinationPath))
                Directory.CreateDirectory(DestinationPath);

            var fullPath = $@"{DestinationPath}{fileName}";
            File.WriteAllText(fullPath, csvText);
            return fullPath;
        }

        internal static void OpenFile(string path)
        {
            Process.Start(path);
        }

        internal static void OpenSaveDestinationFolder()
        {
            Process.Start(DestinationPath);
        }

    }
}
