using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerModel
{
    public class RollSummary
    {
        public RollSummary(int rollCount, double width, double thickness, double totalLength, double totalWeight, DateTime lastDateCreated, DateTime firstDateCreated)
        {
            RollCount = rollCount > 0 ? rollCount : throw new ArgumentException("rollCount");
            Width = width > 0 ? width : throw new ArgumentException("width");
            Thickness = thickness > 0 ? thickness : throw new ArgumentException("thickness");
            TotalLength = totalLength >= 0 ? totalLength : throw new ArgumentException("total length");
            TotalWeight = totalWeight >= 0 ? totalWeight : throw new ArgumentException("total weigth");

            if (firstDateCreated > lastDateCreated)
                throw new ArgumentException("firstDate larger than lastDate");
            LastDateCreated = lastDateCreated;
            FirstDateCreated = firstDateCreated;
        }

        public RollSummary(DataRow row)
        {

        }

        public int RollCount { get; private set; }

        public double Width { get; private set; }

        public double Thickness { get; private set; }

        public double TotalLength { get; private set; }

        public double TotalWeight { get; private set; }

        public DateTime LastDateCreated { get; private set; }

        public DateTime FirstDateCreated { get; private set; }
    }
}
