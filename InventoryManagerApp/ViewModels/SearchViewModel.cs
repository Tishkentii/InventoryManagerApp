using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using InventoryManagerModel;

namespace InventoryManagerApp.ViewModels
{
    class SearchViewModel : ViewModelBase
    {
        public SearchViewModel()
        {
            Criteria = new SearchCriteria();
        }

        #region Properties

        public SearchCriteria Criteria { get; set; }


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
