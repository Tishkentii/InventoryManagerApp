using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerModel
{
    public class RollDimentions
    {
        public RollDimentions(double width, double thickness, double length, double weight)
        {
            Width = width >= 0.0 ? width : throw new ArgumentException("width");
            Thickness = thickness >= 0.0 ? thickness : throw new ArgumentException("thickness");
            Length = length >= 0.0 ? length : throw new ArgumentException("length");
            Weight = weight >= 0.0 ? weight : throw new ArgumentException("realWeight");
        }

        public double Width { get; private set; }

        public double Thickness { get; private set; }

        public double Length { get; private set; }

        public double Weight { get; private set; }

        //public double CalculatedWeight { get; set; }


    }
}
