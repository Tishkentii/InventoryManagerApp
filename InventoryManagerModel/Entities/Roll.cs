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
        public Roll(int id, RollSize size, string producedBy, double length, double weight, string notes, DateTime createdOn, DateTime? consumedOn)
        {
            RollID = id > 0 ? id : throw new ArgumentException("Invalid id");
            Size = size ?? throw new ArgumentNullException("size is null");
            ProducedBy = !String.IsNullOrEmpty(producedBy) ? producedBy : throw new ArgumentException("Invalid producedBy");
            Length = length > 0 ? length : throw new ArgumentException("Invalid length");
            Weight = weight > 0 ? weight : throw new ArgumentException("Invalid weight");
            Notes = notes ?? throw new ArgumentException("Invalid notes");
            if (consumedOn.HasValue && createdOn > consumedOn.Value)
                throw new ArgumentException("Invalid createdOn/consumedOn");
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
