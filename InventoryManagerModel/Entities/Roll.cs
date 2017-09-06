using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerModel.Entities
{
    public class Roll
    {
        public Roll(int id, RollSize size, string producesBy, double length, double weight, string notes, DateTime createdOn, DateTime? consumedOn = null)
        {
            RollID = id > 0 ? id : throw new ArgumentException("id");
            Size = size;
            ProducedBy = !String.IsNullOrEmpty(producesBy) ? producesBy : throw new ArgumentException("producedBy");
            Length = length > 0 ? length : throw new ArgumentException("length");
            Weight = weight > 0 ? weight : throw new ArgumentException("weight");
            Notes = notes ?? throw new ArgumentException("comment");
            if (consumedOn.HasValue && createdOn > consumedOn.Value)
                throw new ArgumentException("createdOn/consumedOn");
            CreatedOn = createdOn;
            ConsumedOn = consumedOn;
        }

        public int RollID { get; private set; }

        public RollSize Size { get; private set; }

        public string ProducedBy { get; private set; }

        public double Length { get; private set; }

        public double Weight { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public DateTime? ConsumedOn { get; private set; }

        public string Notes { get; private set; }
    }
}
