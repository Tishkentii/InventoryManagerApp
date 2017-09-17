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
        readonly BusinessService _businessService;

        public MainViewModel() { }

        public MainViewModel(BusinessService businessService)
        {
            _businessService = businessService;
            MessengerInstance.Register<SearchCriteria>(this, OnSearch);
        }

        #region Binding properties

        ViewModelBase _activePanelVM;
        public ViewModelBase ActivePanelVM
        {
            get => _activePanelVM;
            set => Set(ref _activePanelVM, value);
        }

        ResultViewModel _resultViewModel;
        public ResultViewModel ResultVM
        {
            get => _resultViewModel;
            set => Set(ref _resultViewModel, value);
        }

        OptionPanelType _activePanelType;
        public OptionPanelType ActivePanelType
        {
            get => _activePanelType;
            set => Set(ref _activePanelType, value);
        }

        #endregion

        #region Commands
        // TODO make search and save buttons toggle the pannels
        RelayCommand _showSearchCommand;
        public ICommand ShowSearchCommand =>
            _showSearchCommand ?? (_showSearchCommand = new RelayCommand(ShowSearch));

        RelayCommand _showSaveCommand;
        public ICommand ShowSaveCommand =>
            _showSaveCommand ?? (_showSaveCommand = new RelayCommand(ShowSave, () => _resultViewModel != null));

        RelayCommand _synchronizeDatabasesCommand;
        public ICommand SynchronizeDatabasesCommand =>
            _synchronizeDatabasesCommand ?? (_synchronizeDatabasesCommand = new RelayCommand(async () => await SynchronizeDatabasesAsync()));

        #endregion

        void ShowSearch()
        {
            ActivePanelVM = new SearchViewModel();
            ActivePanelType = OptionPanelType.None;
            ActivePanelType = OptionPanelType.Search;
        }

        void ShowSave()
        {
            ActivePanelVM = new SaveViewModel(_businessService, ResultVM.Summaries);
            ActivePanelType = OptionPanelType.None;
            ActivePanelType = OptionPanelType.Save;

        }

        async void OnSearch(SearchCriteria criteria)
        {
            var summary = await _businessService.GetRollsSummaryAsync(criteria);
            ResultVM = new ResultViewModel(_businessService, criteria, summary);
            ActivePanelType = OptionPanelType.None;
            _showSaveCommand.RaiseCanExecuteChanged();
        }

        async Task SynchronizeDatabasesAsync()
        {
            try
            {
                await _businessService.SynchronizeDatabasesAsync();
                MessageBox.Show("Синхронизацията успешна.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Синхронизацията неуспешна.\n{ex.Message}", "Провал", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    public enum OptionPanelType
    {
        None,
        Search,
        Save,
        Options
    }
}
