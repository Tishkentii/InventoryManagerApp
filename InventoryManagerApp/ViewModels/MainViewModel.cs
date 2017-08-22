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

            MessengerInstance.Register<SearchCriteria>(this, PerformSearch);
        }

        #region Binding properties

        SearchViewModel _searchViewModel;
        public SearchViewModel SearchVM
        {
            get => _searchViewModel;
            set => Set(ref _searchViewModel, value);
        }

        ResultViewModel _resultViewModel;
        public ResultViewModel ResultVM
        {
            get => _resultViewModel;
            set => Set(ref _resultViewModel, value);
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

        public async void PerformSearch(SearchCriteria criteria)
        {
            var summary = await _rollService.GetRollsSummaryAccordingToCriteriaAsync(criteria).ConfigureAwait(false);
            ResultVM = new ResultViewModel(_rollService, criteria, summary);
            SearchVM = null;
        }
    }
}
