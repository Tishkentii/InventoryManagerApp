using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerModel.Entities
{
    public class RollSize
    {
        public RollSize(int sizeID, RollType type, int width, int thickness)
        {
            SizeID = sizeID;
            Type = type;
            Width = width;
            Thickness = thickness;
        }

        public int SizeID
        {
            get; private set;
        }

        public RollType Type
        {
            get; private set;
        }

        public int Width
        {
            get; private set;
        }

        public int Thickness
        {
            get; private set;
        }


    }
}
