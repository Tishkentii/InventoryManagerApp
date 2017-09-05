﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagerModel;
using InventoryManagerModel.DTOs;
using InventoryManagerModel.Entities;

namespace InventoryManagerDataAccess.Internal
{
    internal class CommandStringHelper
    {
        static Dictionary<string, string> _accessToSqlColumnMapping = new Dictionary<string, string>
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

        #region Properties

        internal static Dictionary<string, string> AccessToSqlColumnMapping =>
            _accessToSqlColumnMapping;

        internal static string LastCreatedRollIDCommandString =>
                "SELECT max(ID) FROM dbo.Rolls";

        #endregion

        internal static string GetLatestAccessDataCommandString(int lastRollAddedID)
        {
            return $"SELECT rolkaID, Код, Тип, [Ширина (mm)], ROUND([Дължина (m)],2) as [Дължина (m)], [Дебелина (µm)], ROUND([Изч тегло (kg)],2) as [Изч тегло (kg)], ROUND([Изм тегло (kg)],2) as [Изм тегло (kg)], Екструдерист, [Дата/Час], [Коментар екстр] FROM rolki WHERE rolkaID > {lastRollAddedID}";
        }

        internal static string GetRollSummaryCommandString(SearchCriteria criteria)
        {
            if (criteria == null)
                throw new ArgumentNullException("criteria");

            var builder = new StringBuilder($"SELECT COUNT(r2.id) AS RollCount, Type, Width, Thickness, sum(Length) AS TotalLength, sum(WeightReal) AS TotalWeight, min(Createdon) AS FirstDateCreated, max(createdon) AS LastDateCreated FROM dbo.Rolls WHERE Type = ");
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
                        builder.Append($" AND CreatedOn >= '{criteria.CreatedAfterDate.Value.ToString("yyyy-MM-dd")}'");
                    if (criteria.CreatedBeforeDate.HasValue)
                        builder.Append($" AND CreatedOn <= '{criteria.CreatedBeforeDate.Value.ToString("yyyy-MM-dd")}'");
                    break;
                case SearchType.Consumption:
                    builder.Append(" AND ConsumedOn is not null");
                    if (criteria.CreatedAfterDate.HasValue)
                        builder.Append($" AND ConsumedOn >= '{criteria.CreatedAfterDate.Value.ToString("yyyy-MM-dd")}'");
                    if (criteria.CreatedBeforeDate.HasValue)
                        builder.Append($" AND ConsumedOn <= '{criteria.CreatedBeforeDate.Value.ToString("yyyy-MM-dd")}'");
                    break;
            }
            builder.Append(" GROUP BY Type, Width, Thickness");
            return builder.ToString();
        }

        internal static string GetSummaryDetailsCommandString(SearchType searchType, RollSummary summary)
        {
            string rollType = summary.Type == RollType.Film ? "I" : "O";
            var builder = new StringBuilder($"SELECT * FROM dbo.Rolls WHERE Type = '{rollType}' AND Width = {summary.Width} AND Thickness = {summary.Thickness}");
            switch (searchType)
            {
                case SearchType.Stock:
                    builder.Append("AND ConsumedOn is null");
                    break;
                case SearchType.Consumption:
                    builder.Append("AND ConsumedOn is not null");
                    break;
            }
            return builder.ToString();
        }
    }
}