using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerModel.DTOs
{
    public class SummaryFileInfo
    {
        public SummaryFileInfo(string name, string path)
        {
            Name = name;
            Path = path;
        }

        public string Name
        {
            get; set;
        }

        public string Path
        {
            get; set;
        }
    }
}
