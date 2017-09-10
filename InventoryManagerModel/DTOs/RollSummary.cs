using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagerModel.Entities;

namespace InventoryManagerModel.DTOs
{
    public class RollSummary
    {
        public RollSummary(RollSize rollSize, int rollCount, double totalLength, double totalWeight, DateTime? lastDateCreated, DateTime? firstDateCreated)
        {
            RollSize = rollSize ?? throw new ArgumentException("rollSize");
            RollCount = rollCount >= 0 ? rollCount : throw new ArgumentException("rollCount");
            TotalLength = totalLength >= 0 ? totalLength : throw new ArgumentException("total length");
            TotalWeight = totalWeight >= 0 ? totalWeight : throw new ArgumentException("total weigth");

            if (firstDateCreated > lastDateCreated)
                throw new ArgumentException("firstDate larger than lastDate");
            LastDateCreated = lastDateCreated;
            FirstDateCreated = firstDateCreated;
        }

        public RollSize RollSize { get; private set; }

        public int RollCount { get; private set; }

        public double TotalLength { get; private set; }

        public double TotalWeight { get; private set; }

        public DateTime? LastDateCreated { get; private set; }

        public DateTime? FirstDateCreated { get; private set; }

        #region Overrides

        public override bool Equals(object obj)
        {
            if (obj is RollSummary summary)
            {
                return
                RollCount == ((RollSummary)obj).RollCount &&
                   RollSize == ((RollSummary)obj).RollSize &&
                   TotalLength == ((RollSummary)obj).TotalLength &&
                   TotalWeight == ((RollSummary)obj).TotalWeight &&
                   LastDateCreated == ((RollSummary)obj).LastDateCreated &&
                   FirstDateCreated == ((RollSummary)obj).FirstDateCreated;
            }
            else
                return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion
    }
}
