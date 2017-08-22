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
            _searchCriteria = new SearchCriteria()
            {
                Width = 200,
                Thickness = 70,
                SearchType = SearchType.Stock
            };
            Summary = new List<RollSummary>()
            {
                new RollSummary(10, 200, 7, 100.12, 4381, DateTime.Now, DateTime.Now),
                new RollSummary(12, 100, 7, 70.12, 481, DateTime.Now, DateTime.Now),
                new RollSummary(30, 400, 12, 100.12, 4381, DateTime.Now, DateTime.Now),
                new RollSummary(9, 220, 9, 700.12, 1381, DateTime.Now, DateTime.Now),
                new RollSummary(5, 440, 12, 120.12, 3381, DateTime.Now, DateTime.Now),
            };
            Rolls = new List<Roll> { new Roll(1), new Roll(2), new Roll(3) };
        }

        public ResultViewModel(RollService rollService, SearchCriteria criteria, IEnumerable<RollSummary> summary)
        {
            _rollService = rollService;
            _searchCriteria = criteria;
            Summary = summary;
        }

        #region Properties

        SearchCriteria _searchCriteria;
        public SearchCriteria SearchCriteria
        {
            get => _searchCriteria;
            set => Set(ref _searchCriteria, value);
        }

        public IEnumerable<RollSummary> Summary
        {
            get;
            private set;
        }

        public RollSummary SelectedSummary
        {
            get;
            set;
        }


        IEnumerable<Roll> _rolls;
        public IEnumerable<Roll> Rolls
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
            _showDetailsCommand ?? (_showDetailsCommand = new RelayCommand(ShowDetails));

        RelayCommand _hideDetailsCommand;
        public ICommand HideDetailsCommand =>
            _hideDetailsCommand ?? (_hideDetailsCommand = new RelayCommand(HideDetails));

        #endregion

        public void ShowDetails()
        {
            Rolls = _rollService.GetRollDetailsFromSummary(SelectedSummary);
            DetailsVisible = true;
        }

        public void HideDetails()
        {
            DetailsVisible = false;
        }

    }
}
