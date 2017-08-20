using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InventoryManagerApp.Properties;
using InventoryManagerDataAccess;
using InventoryManagerModel;
using InventoryManagerServices;

namespace InventoryManagerApp.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        readonly RollService _rollService;

        public MainViewModel()
        {
            _rollService = new RollService(new MsSqlRepository("test"), new MsAccessRepository("test"));
            //SearchVM = new SearchViewModel();

            MessengerInstance.Register<SearchCriteria>(this, HideSearch);
        }

        #region Binding properties

        SearchViewModel _searchViewModel;
        public SearchViewModel SearchVM
        {
            get => _searchViewModel;
            set
            {
                _searchViewModel = value;
                RaisePropertyChanged(nameof(SearchVM));
            }
        }

        ResultViewModel _resultViewModel;
        public ResultViewModel ResultVM
        {
            get => _resultViewModel;
            set
            {
                _resultViewModel = value;
                RaisePropertyChanged(nameof(ResultVM));
            }
        }

        #endregion

        #region Commands

        RelayCommand _showSearchCommand;
        public ICommand ShowSearchCommand =>
            _showSearchCommand ?? (_showSearchCommand = new RelayCommand(ShowSearch));

        #endregion

        public void ShowSearch()
        {
            SearchVM = new SearchViewModel();
            //ResultVM = null;
        }

        public void HideSearch(SearchCriteria criteria)
        {
            ResultVM = new ResultViewModel(_rollService, criteria);
            SearchVM = null;
        }
    }
}
