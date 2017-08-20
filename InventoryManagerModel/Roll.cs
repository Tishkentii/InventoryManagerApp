using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerModel
{
    public class Roll
    {
        public Roll(int id)
        {
            ID = id;
        }

        public Roll(DataRow rollData)
        {
            // TODO parse data
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
