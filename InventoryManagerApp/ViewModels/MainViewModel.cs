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
            _rollService = new RollService(new MsSqlRepository(Settings.Default.MsSqlConnectionString), new MsAccessRepository(Settings.Default.MsAccessConnectionString));

            MessengerInstance.Register<SearchCriteria>(this, OnSearch);
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

        bool _searchVisible;
        public bool SearchVisible
        {
            get => _searchVisible;
            set => Set(ref _searchVisible, value);
        }

        #endregion

        #region Commands

        RelayCommand _showSearchCommand;
        public ICommand ShowSearchCommand =>
            _showSearchCommand ?? (_showSearchCommand = new RelayCommand(ShowSearch));

        RelayCommand _synchronizeDatabasesCommand;
        public ICommand SynchronizeDatabasesCommand =>
            _synchronizeDatabasesCommand ?? (_synchronizeDatabasesCommand = new RelayCommand(async () => await SynchronizeDatabasesAsync()));

        #endregion

        public void ShowSearch()
        {
            SearchVM = new SearchViewModel();
            SearchVisible = true;
            //ResultVM = null;
        }

        public async void OnSearch(SearchCriteria criteria)
        {
            var summary = await _rollService.GetRollsSummaryAccordingToCriteriaAsync(criteria).ConfigureAwait(false);
            ResultVM = new ResultViewModel(_rollService, criteria, summary);
            //ResultVM = new ResultViewModel();
            SearchVisible = false;
        }

        public async Task SynchronizeDatabasesAsync()
        {
            try
            {
                await _rollService.SynchronizeDatabasesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
                // TODO Show message box
            }
        }
    }
}
