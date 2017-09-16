using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using InventoryManagerModel.DTOs;

namespace InventoryManagerServices
{
    internal class CSVService
    {
        internal static string ConvertSummariesToCSV(IEnumerable<RollSummary> summaries)
        {
            List<string> summaryText = new List<string>()
            {
                $"Ширина (мм);Дебелина (μ);Тип;Брой ролки;Обша дължина (м);Общо тегло (кг);Най-рано произведена;Най-късно проезведена"
            };
            summaryText.AddRange(summaries.Select(s => String.Join(";", s.RollSize.Width, s.RollSize.Thickness, s.RollSize.Type, s.RollCount, s.TotalLength, s.TotalWeight, s.FirstDateCreated, s.LastDateCreated)));
            string result = String.Join(Environment.NewLine, summaryText);
            return result;
        }

        static string GetSummariesHeader()
        {
            var builder = new StringBuilder();
            PropertyInfo[] headerInfo = typeof(RollSummary).GetProperties();
            foreach (var info in headerInfo)
                builder.Append($"{info.Name};");
            builder.Remove(builder.Length - 2, 1);
            return builder.ToString();
        }
    }
}
