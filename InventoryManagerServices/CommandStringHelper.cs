using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagerModel;

namespace InventoryManagerServices
{
    public class CommandStringHelper
    {
        #region Properties

        public static Dictionary<string, string> AccessToSqlColumnMapping =>
            new Dictionary<string, string>
            {
                { "rolkaID", "ID" },
                { "Код", "Code" },
                { "Тип", "Type" },
                { "Ширина (mm)", "Width" },
                { "Дължина (m)", "Length" },
                { "Дебелина (µm)", "Thickness" },
                { "Изч тегло (kg)", "WeightCalc" },
                { "Изм тегло (kg)", "WeightReal" },
                { "Екструдерист", "Employee" },
                { "Дата/Час", "CreatedOn" },
                { "Коментар екстр", "Comment" }
            };

        public static string LastCreatedRollIDCommandString =>
                "SELECT max(ID) FROM dbo.Rolls";

        #endregion

        public static string GetSynchonizationCommandString(int lastRollAddedID)
        {
            return $"SELECT rolkaID, Код, Тип, [Ширина (mm)], ROUND([Дължина (m)],2) as [Дължина (m)], [Дебелина (µm)], ROUND([Изч тегло (kg)],2) as [Изч тегло (kg)], ROUND([Изм тегло (kg)],2) as [Изм тегло (kg)], Екструдерист, [Дата/Час], [Коментар екстр] FROM rolki WHERE rolkaID > {lastRollAddedID}";
        }

        public static string GetRollSummaryCommandString(SearchCriteria criteria)
        {
            if (criteria == null)
                throw new ArgumentNullException("criteria");

            var builder = new StringBuilder($"SELECT * FROM dbo.Rolls WHERE Type = ");
            builder.Append(criteria.RollType == RollType.Tube ? "'O'" : "'I'");
            if (criteria.Width.HasValue)
                builder.Append($" AND Width = {criteria.Width.Value}");
            if (criteria.Thickness.HasValue)
                builder.Append($" AND Thickness = {criteria.Thickness.Value}");
            switch (criteria.SearchType)
            {
                case SearchType.Stock:
                    builder.Append($" AND ConsumedOn is null");
                    break;
                case SearchType.Production:
                    if (criteria.CreatedAfterDate.HasValue)
                        builder.Append($" AND CreatedOn >= '{criteria.CreatedAfterDate.Value}'");
                    if (criteria.CreatedBeforeDate.HasValue)
                        builder.Append($" AND CreatedOn <= '{criteria.CreatedBeforeDate.Value}'");
                    break;
                case SearchType.Consumption:
                    builder.Append(" AND ConsumedOn is not null");
                    if (criteria.CreatedAfterDate.HasValue)
                        builder.Append($" AND ConsumedOn >= '{criteria.CreatedAfterDate.Value}'");
                    if (criteria.CreatedBeforeDate.HasValue)
                        builder.Append($" AND ConsumedOn <= '{criteria.CreatedBeforeDate.Value}'");
                    break;
            }
            return builder.ToString();
        }
    }
}
