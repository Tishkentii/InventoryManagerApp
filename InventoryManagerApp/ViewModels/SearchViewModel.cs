using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using InventoryManagerModel;
using InventoryManagerModel.DTOs;

namespace InventoryManagerApp.ViewModels
{
    class SearchViewModel : ViewModelBase
    {
        public SearchViewModel()
        {
            Criteria = new SearchCriteria();
        }

        #region Properties

        public SearchCriteria Criteria
        {
            get;
            set;
        }

        public bool DatesVisible =>
            Criteria.SearchType != SearchType.Stock;

        #endregion

        #region Commands

        RelayCommand _searchCommand;
        public ICommand SearchCommand =>
            _searchCommand ?? (_searchCommand = new RelayCommand(SendSearch));

        #endregion

        public void SendSearch()
        {
            MessengerInstance.Send(Criteria);
        }
    }
}
