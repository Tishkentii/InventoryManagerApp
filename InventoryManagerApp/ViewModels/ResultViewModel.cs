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
using InventoryManagerModel.DTOs;
using InventoryManagerModel.Entities;
using InventoryManagerServices;

namespace InventoryManagerApp.ViewModels
{
    class ResultViewModel : ViewModelBase
    {
        readonly BusinessService _rollService;
        readonly SearchCriteria _searchCriteria;

        public ResultViewModel() { }

        public ResultViewModel(BusinessService rollService, SearchCriteria criteria, ICollection<RollSummary> summaries)
        {
            _rollService = rollService;
            _searchCriteria = criteria;
            Summaries = summaries;
            SearchSummaryString = SetSearchSummaryString(criteria);
        }

        #region Properties

        public string SearchSummaryString
        {
            get; private set;
        }

        public ICollection<RollSummary> Summaries
        {
            get; private set;
        }

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

        async Task ShowDetails()
        {
            Rolls = await _rollService.GetRollDetailsAsync(_searchCriteria.SearchType, SelectedSummary);
            DetailsVisible = true;
        }

        void HideDetails()
        {
            DetailsVisible = false;
        }

        string SetSearchSummaryString(SearchCriteria searchCriteria)
        {
            var builder = new StringBuilder("Резултати от търсене в ");
            switch (searchCriteria.SearchType)
            {
                case SearchType.Stock:
                    builder.Append("СКЛАД ");
                    break;
                case SearchType.Production:
                    builder.Append("ПРОИЗВЕДЕНИ ");
                    break;
                case SearchType.Consumption:
                    builder.Append("ИЗРАБОТЕНИ ");
                    break;
            }
            builder.Append("на ролки тип ");
            builder.Append(searchCriteria.RollType == RollType.Tube ? "РЪКАВ" : "ДВОЙНО ЦЕПЕНО");
            if (searchCriteria.Width.HasValue)
                builder.Append($" и ШИРИНА = {searchCriteria.Width.Value}");
            if (searchCriteria.Thickness.HasValue)
                builder.Append($" и ДЕБЕЛИНА = {searchCriteria.Thickness.Value}");
            if (searchCriteria.CreatedAfterDate.HasValue)
                builder.Append($" и ПРОИЗВЕДЕНА СЛЕД {searchCriteria.CreatedAfterDate.Value.ToShortDateString()}");
            if (searchCriteria.CreatedBeforeDate.HasValue)
                builder.Append($" и ПРОИЗВЕДЕНА ПРЕДИ {searchCriteria.CreatedBeforeDate.Value.ToShortDateString()}");
            return builder.ToString();
        }

    }
}
