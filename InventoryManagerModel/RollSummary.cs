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
        public RollSummary(int rollCount, int width, int thickness, double totalLength, double totalWeight, DateTime lastDateCreated, DateTime firstDateCreated)
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
            RollCount = Convert.ToInt32(row["RollCount"]);
            Width = Convert.ToInt32(row["Width"]);
            Thickness = Convert.ToInt32(row["Thickness"]);
            TotalLength = Convert.ToDouble(row["TotalLength"]);
            TotalWeight = Convert.ToDouble(row["TotalWeight"]);
            LastDateCreated = Convert.ToDateTime(row["LastDateCreated"]);
            FirstDateCreated = Convert.ToDateTime(row["FirstDateCreated"]);
        }

        public int RollCount { get; private set; }

        public int Width { get; private set; }

        public int Thickness { get; private set; }

        public double TotalLength { get; private set; }

        public double TotalWeight { get; private set; }

        public DateTime LastDateCreated { get; private set; }

        public DateTime FirstDateCreated { get; private set; }

        #region Overrides

        public override bool Equals(object obj)
        {
            return RollCount == ((RollSummary)obj).RollCount &&
                   Width == ((RollSummary)obj).Width &&
                   Thickness == ((RollSummary)obj).Thickness &&
                   TotalLength == ((RollSummary)obj).TotalLength &&
                   TotalWeight == ((RollSummary)obj).TotalWeight &&
                   LastDateCreated == ((RollSummary)obj).LastDateCreated &&
                   FirstDateCreated == ((RollSummary)obj).FirstDateCreated;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
