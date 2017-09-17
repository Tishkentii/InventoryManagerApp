using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerModel.Entities
{
    public class RollSummary
    {
        public RollSummary(RollSize rollSize, int rollCount, double totalLength, double totalWeight, DateTime? firstDateCreated, DateTime? lastDateCreated)
        {
            ValidateConstructorParams(rollSize, rollCount, totalLength, totalWeight, firstDateCreated, lastDateCreated);

            RollSize = rollSize;
            RollCount = rollCount;
            TotalLength = totalLength;
            TotalWeight = totalWeight;

            LastDateCreated = lastDateCreated;
            FirstDateCreated = firstDateCreated;
        }

        void ValidateConstructorParams(RollSize rollSize, int rollCount, double totalLength, double totalWeight, DateTime? firstDateCreated, DateTime? lastDateCreated)
        {
            if (rollSize == null)
                throw new ArgumentNullException("rollSize is null");

            if (rollCount < 0 || totalLength < 0 || totalWeight < 0)
                throw new ArgumentException("Invalid rollCoutn, totalLenth or totalWeight");

            if (rollCount == 0 || totalWeight == 0 || totalLength == 0 || firstDateCreated == null || lastDateCreated == null)
            {
                if (rollCount > 0 || totalWeight > 0 || totalLength > 0 || firstDateCreated != null || lastDateCreated != null)
                    throw new ArgumentException("Invalid rollCount, totalLenth or totalWeight or Dates not null");
            }

            if (firstDateCreated.HasValue && lastDateCreated.HasValue && firstDateCreated > lastDateCreated)
                throw new ArgumentException("firstDate larger than lastDate");
        }

        public RollSize RollSize
        {
            get; private set;
        }

        public int RollCount
        {
            get; private set;
        }

        public double TotalLength
        {
            get; private set;
        }

        public double TotalWeight
        {
            get; private set;
        }

        public DateTime? LastDateCreated
        {
            get; private set;
        }

        public DateTime? FirstDateCreated
        {
            get; private set;
        }



    }
}