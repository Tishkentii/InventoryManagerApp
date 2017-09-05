using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InventoryManagerModel.DTOs;
using InventoryManagerServices;

namespace InventoryManagerApp.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        readonly BusinessService _service;

        public MainViewModel() { }

        public MainViewModel(BusinessService service)
        {
            _service = service;

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
        }

        public async void OnSearch(SearchCriteria criteria)
        {
            var summary = await _service.GetRollsSummaryAsync(criteria).ConfigureAwait(false);
            ResultVM = new ResultViewModel(_service, criteria, summary);
            SearchVisible = false;
        }

        public async Task SynchronizeDatabasesAsync()
        {
            try
            {
                await _service.SynchronizeDatabasesAsync();
                MessageBox.Show("Синхронизацията успешна.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Синхронизацията неуспешна.\n{ex.Message}", "Провал", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
