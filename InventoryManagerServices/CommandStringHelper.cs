using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagerModel;

namespace InventoryManagerServices
{
    internal static class CommandStringHelper
    {
        internal static Dictionary<string, string> AccessToSqlColumnMapping =>
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

        internal static string GetSynchonizationCommandString(int lastRollAddedID)
        {
            return $"SELECT rolkaID, Код, Тип, [Ширина (mm)], ROUND([Дължина (m)],2) as [Дължина (m)], [Дебелина (µm)], ROUND([Изч тегло (kg)],2) as [Изч тегло (kg)], ROUND([Изм тегло (kg)],2) as [Изм тегло (kg)], Екструдерист, [Дата/Час], [Коментар екстр] FROM rolki WHERE rolkaID > {lastRollAddedID}";
        }

        internal static string GetRollSummaryCommandString(SearchCriteria criteria)
        {
            var builder = new StringBuilder("SELECT * FROM dbo.Rolls where");

        }
    }
}
