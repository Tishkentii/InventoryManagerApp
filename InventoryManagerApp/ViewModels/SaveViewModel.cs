using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using InventoryManagerModel;
using InventoryManagerModel.Entities;
using InventoryManagerServices;

namespace InventoryManagerApp.ViewModels
{
    public class SaveViewModel : ViewModelBase
    {
        readonly BusinessService _businessService;
        readonly ICollection<RollSummary> _rollSummaries;

        public SaveViewModel(BusinessService businessService, ICollection<RollSummary> rollSummaries)
        {
            _businessService = businessService;
            _rollSummaries = rollSummaries;
            OpenAfterSave = true;
            FileName = $"{DateTime.Today.ToShortDateString()}-{rollSummaries.First().RollSize.Type}";
        }

        #region Properties

        public bool OpenAfterSave
        {
            get; set;
        }

        public string FileName
        {
            get; set;
        }

        #endregion

        RelayCommand _saveSummariesCommand;
        public ICommand SaveSummariesCommand =>
            _saveSummariesCommand ?? (_saveSummariesCommand = new RelayCommand(SaveSummaries, () => _rollSummaries.Count > 0 && !String.IsNullOrEmpty(FileName)));

        RelayCommand _openSaveFolderCommand;
        public ICommand OpenSaveFolderDestinationCommand =>
            _openSaveFolderCommand ?? (_openSaveFolderCommand = new RelayCommand(_businessService.OpenSaveDestinationFoler));


        void SaveSummaries()
        {
            _businessService.SaveSummaries(_rollSummaries, FileName, OpenAfterSave);
        }
    }
}
