using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerModel
{
    public class SearchCriteria : BaseModel
    {
        public SearchCriteria()
        {
            _searchType = SearchType.Stock;
            _rollType = RollType.Tube;
        }

        #region Properties

        SearchType _searchType;
        public SearchType SearchType
        {
            get => _searchType;
            set => SetProperty(ref _searchType, value);
        }

        RollType _rollType;
        public RollType RollType
        {
            get => _rollType;
            set => SetProperty(ref _rollType, value);
        }

        public int? Width
        {
            get;
            set;
        }

        public int? Thickness
        {
            get;
            set;
        }

        public DateTime? CreatedAfterDate
        {
            get;
            set;
        }

        public DateTime? CreatedBeforeDate
        {
            get;
            set;
        }

        #endregion


    }
}
