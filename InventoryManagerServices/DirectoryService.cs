using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagerModel.DTOs;

namespace InventoryManagerServices
{
    public class DirectoryService
    {
        // todo inject dir where files are to be saved

        public ICollection<SummaryFileInfo> GetSummaryFilesInDirectory()
        {
            var result = new HashSet<SummaryFileInfo>();
            var fullPaths = Directory.GetFiles(Directory.GetCurrentDirectory());
            foreach (var path in fullPaths)
            {
                result.Add(new SummaryFileInfo(Path.GetFileName(path), path));
            }
            return result;
        }
    }
}
