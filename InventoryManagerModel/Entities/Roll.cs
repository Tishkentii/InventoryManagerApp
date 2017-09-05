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
        public Roll(int id, RollType type, string producesBy, int width, int thickness, double length, double weight, string comment, DateTime createdOn, DateTime? consumedOn = null)
        {
            ID = id > 0 ? id : throw new ArgumentException("id");
            Type = type;
            ProducedBy = !String.IsNullOrEmpty(producesBy) ? producesBy : throw new ArgumentException("producedBy");
            Width = width > 0 ? width : throw new ArgumentException("width");
            Thickness = thickness > 0 ? thickness : throw new ArgumentException("thickness");
            Length = length > 0 ? length : throw new ArgumentException("length");
            Weight = weight > 0 ? weight : throw new ArgumentException("weight");
            Comment = comment ?? throw new ArgumentException("comment");
            if (consumedOn.HasValue && createdOn > consumedOn.Value)
                throw new ArgumentException("createdOn/consumedOn");
            CreatedOn = createdOn;
            ConsumedOn = consumedOn;
        }

        public int ID { get; private set; }

        public RollType Type { get; private set; }

        public string ProducedBy { get; private set; }

        public double Width { get; private set; }

        public double Thickness { get; private set; }

        public double Length { get; private set; }

        public double Weight { get; private set; }

        public DateTime CreatedOn { get; private set; }

        public DateTime? ConsumedOn { get; private set; }

        public string Comment { get; private set; }
    }
}
