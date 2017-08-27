using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InventoryManagerModel;
using InventoryManagerServices;

namespace InventoryManagerApp.ViewModels
{
    class ResultViewModel : ViewModelBase
    {
        readonly RollService _rollService;

        public ResultViewModel()
        {
            SearchCriteria = new SearchCriteria()
            {
                Width = 200,
                Thickness = 70,
                SearchType = SearchType.Stock
            };
            Summaries = new List<RollSummary>()
            {
                new RollSummary(RollType.Tube,10, 200, 7, 100.12, 4381, DateTime.MaxValue, DateTime.MinValue),
                new RollSummary(RollType.Tube,12, 100, 7, 70.12, 481, DateTime.MaxValue, DateTime.MinValue),
                new RollSummary(RollType.Tube,30, 400, 12, 100.12, 4381, DateTime.MaxValue, DateTime.MinValue),
            };
            Rolls = new List<Roll> { new Roll(1), new Roll(2), new Roll(3) };
        }

        public ResultViewModel(RollService rollService, SearchCriteria criteria, ICollection<RollSummary> summaries)
        {
            _rollService = rollService;
            SearchCriteria = criteria;
            Summaries = summaries;
        }

        #region Properties

        public SearchCriteria SearchCriteria { get; private set; }

        public ICollection<RollSummary> Summaries { get; private set; }

        RollSummary _selectedSummary;
        public RollSummary SelectedSummary
        {
            get => _selectedSummary;
            set => Set(ref _selectedSummary, value);
        }


        ICollection<Roll> _rolls;
        public ICollection<Roll> Rolls
        {
            get => _rolls;
            set => Set(ref _rolls, value);
        }

        bool _detailsVisible;
        public bool DetailsVisible
        {
            get => _detailsVisible;
            set => Set(ref _detailsVisible, value);
        }

        #endregion

        #region Commands

        RelayCommand _showDetailsCommand;
        public ICommand ShowDetailsCommand =>
            _showDetailsCommand ?? (_showDetailsCommand = new RelayCommand(async () => await ShowDetails()));

        RelayCommand _hideDetailsCommand;
        public ICommand HideDetailsCommand =>
            _hideDetailsCommand ?? (_hideDetailsCommand = new RelayCommand(HideDetails));

        #endregion

        public async Task ShowDetails()
        {
            //Rolls = await _rollService.GetRollDetailsFromSummaryAsync(SelectedSummary, SearchCriteria.SearchType);
            DetailsVisible = true;
        }

        public void HideDetails()
        {
            DetailsVisible = false;
        }

    }
}
