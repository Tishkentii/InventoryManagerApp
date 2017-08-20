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
                Thickness = 0.70,
                SearchType = SearchType.Stock
            };
            Summary = new List<RollSummary>()
            {
                new RollSummary(10, 200, 0.07, 100.12, 4381, DateTime.Now, DateTime.Now),
                new RollSummary(12, 100, 0.07, 70.12, 481, DateTime.Now, DateTime.Now),
                new RollSummary(30, 400, 0.12, 100.12, 4381, DateTime.Now, DateTime.Now),
                new RollSummary(9, 220, 0.09, 700.12, 1381, DateTime.Now, DateTime.Now),
                new RollSummary(5, 440, 0.12, 120.12, 3381, DateTime.Now, DateTime.Now),
            };
            Rolls = new List<Roll> { new Roll(1), new Roll(2), new Roll(3) };
        }

        public ResultViewModel(RollService rollService, SearchCriteria criteria)
        {
            _rollService = rollService;
            _searchCriteria = criteria;
            Summary = _rollService.GetRollsSummaryAccordingToCriteria(criteria);
        }

        #region Properties

        SearchCriteria _searchCriteria;
        public SearchCriteria SearchCriteria
        {
            get => _searchCriteria;
            set
            {
                _searchCriteria = value;
                RaisePropertyChanged(nameof(SearchCriteria));
            }
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
            set
            {
                _rolls = value;
                RaisePropertyChanged(nameof(Rolls));
            }
        }

        bool _detailsVisible;
        public bool DetailsVisible
        {
            get => _detailsVisible;
            set
            {
                _detailsVisible = value;
                RaisePropertyChanged(nameof(DetailsVisible));
            }
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
