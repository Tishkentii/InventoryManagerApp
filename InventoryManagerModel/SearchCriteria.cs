using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerModel
{
    public class SearchCriteria : INotifyPropertyChanged
    {
        public SearchCriteria()
        {
            _searchType = SearchType.Stock;
            RollType = RollType.Tube;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties

        SearchType _searchType;
        public SearchType SearchType
        {
            get => _searchType;
            set
            {
                _searchType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchType)));
            }
        }

        double _width;
        public double Width
        {
            get => _width;
            set => _width = value >= 0 ? value : throw new ArgumentException("Width cannot be 0 or negative");
        }

        double _thickness;


        public double Thickness
        {
            get => _thickness;
            set => _thickness = value >= 0 ? value : throw new ArgumentException("Thickness cannot be 0 or negative.");
        }

        RollType _rollType;
        public RollType RollType
        {
            get => _rollType;
            set
            {
                _rollType = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RollType)));
            }
        }

        public DateTime? CreatedAfterDate { get; set; }

        public DateTime? CreatedBeforeDate { get; set; }

        #endregion


    }
}
