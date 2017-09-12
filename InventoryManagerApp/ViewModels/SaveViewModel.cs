using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InventoryManagerModel.DTOs;
using InventoryManagerServices;

namespace InventoryManagerApp.ViewModels
{
    public class SaveViewModel : ViewModelBase
    {
        readonly DirectoryService _directoryService;

        public SaveViewModel()
        {
        }

        public SaveViewModel(DirectoryService directoryService)
        {
            _directoryService = directoryService;
            SummaryFiles = new ObservableCollection<SummaryFileInfo>(_directoryService.GetSummaryFilesInDirectory());
        }

        public ObservableCollection<SummaryFileInfo> SummaryFiles
        {
            get; set;
        }
    }
}
