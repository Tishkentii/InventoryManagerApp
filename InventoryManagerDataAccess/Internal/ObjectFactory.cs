using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagerModel;
using InventoryManagerModel.DTOs;
using InventoryManagerModel.Entities;

namespace InventoryManagerDataAccess.Internal
{
    internal class ObjectFactory
    {
        internal static RollSummary CreateRollSummary(DataRow data)
        {
            DateTime? lastCreated, firstCreated;
            if (data["LastDateCreated"] != DBNull.Value)
                lastCreated = Convert.ToDateTime(data["LastDateCreated"]);
            else
                lastCreated = null;
            if (data["FirstDateCreated"] != DBNull.Value)
                firstCreated = Convert.ToDateTime(data["FirstDateCreated"]);
            else
                firstCreated = null;

            return new RollSummary
                (
                    rollSize: CreateRollSize(data),
                    rollCount: Convert.ToInt32(data["Count"]),
                    totalLength: data["TotalLength"] != DBNull.Value ? Convert.ToDouble(data["TotalLength"]) : 0,
                    totalWeight: data["TotalWeight"] != DBNull.Value ? Convert.ToDouble(data["TotalWeight"]) : 0,
                    lastDateCreated: lastCreated,
                    firstDateCreated: firstCreated
                );
        }

        internal static RollSize CreateRollSize(DataRow data)
        {
            return new RollSize
                (
                    sizeID: Convert.ToInt32(data["SizeID"]),
                    type: data["Type"].ToString() == "O" ? RollType.Tube : RollType.Film,
                    width: Convert.ToInt32(data["Width"]),
                    thickness: Convert.ToInt32(data["Thickness"])
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
                    size: CreateRollSize(data),
                    producedBy: data["ProducedBy"].ToString(),
                    length: Convert.ToDouble(data["Length"]),
                    weight: Convert.ToDouble(data["WeightReal"]),
                    notes: data["Notes"].ToString(),
                    createdOn: Convert.ToDateTime(data["CreatedOn"]),
                    consumedOn: consumedOn
                );
        }
    }
}
