using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagerModel;
using InventoryManagerModel.Entities;

namespace InventoryManagerDataAccess.Internal
{
    internal class ObjectFactory
    {
        internal static RollSummary CreateRollSummary(DataRow data)
        {
            return new RollSummary
                (
                    type: data["Type"].ToString() == "O" ? RollType.Tube : RollType.Film,
                    rollCount: Convert.ToInt32(data["RollCount"]),
                    width: Convert.ToInt32(data["Width"]),
                    thickness: Convert.ToInt32(data["Thickness"]),
                    totalLength: Convert.ToDouble(data["TotalLength"]),
                    totalWeight: Convert.ToDouble(data["TotalWeight"]),
                    lastDateCreated: Convert.ToDateTime(data["LastDateCreated"]),
                    firstDateCreated: Convert.ToDateTime(data["FirstDateCreated"])
                );
        }

        internal static Roll CreateRoll(DataRow data)
        {
            DateTime? consumedOn;
            if (data["ConsumedOn"] != DBNull.Value)
                consumedOn = Convert.ToDateTime(data["ConsumedOn"]);
            else
                consumedOn = null;
            return new Roll
                (
                    id: Convert.ToInt32(data["ID"]),
                    type: data["Type"].ToString() == "O" ? RollType.Tube : RollType.Film,
                    producesBy: data["Employee"].ToString(),
                    width: Convert.ToInt32(data["Width"]),
                    thickness: Convert.ToInt32(data["Thickness"]),
                    length: Convert.ToDouble(data["Length"]),
                    weight: Convert.ToDouble(data["WeightReal"]),
                    comment: data["Comment"].ToString(),
                    createdOn: Convert.ToDateTime(data["CreatedOn"]),
                    consumedOn: consumedOn
                );
        }
    }
}
