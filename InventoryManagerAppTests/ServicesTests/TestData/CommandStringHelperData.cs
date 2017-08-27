using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagerModel;
using NUnit.Framework;

namespace InventoryManagerAppTests.ServicesTests
{
    public class CommandStringHelperData
    {
        public static IEnumerable<TestCaseData> GetRollSummaryCommandString_AlwaysCorrect_TestData()
        {
            yield return new TestCaseData(
                new SearchCriteria() { RollType = RollType.Tube, Width = 500, Thickness = 70, SearchType = SearchType.Stock },
                "select COUNT(id) as RollCount, Type, Width, Thickness, sum(Length) as TotalLength, sum(WeightReal) as TotalWeight, min(Createdon) as FirstDateCreated, max(createdon) as LastDateCreated from dbo.rolls where type = 'O' and width = 500 and thickness = 70 and consumedon is null group by Type, Width, Thickness");

            yield return new TestCaseData(
                 new SearchCriteria() { RollType = RollType.Film, SearchType = SearchType.Stock },
                "select COUNT(id) as RollCount, Type, Width, Thickness, sum(Length) as TotalLength, sum(WeightReal) as TotalWeight, min(Createdon) as FirstDateCreated, max(createdon) as LastDateCreated from dbo.rolls where type = 'i' and consumedon is null group by Type, width, thickness");

            yield return new TestCaseData(
                new SearchCriteria() { RollType = RollType.Tube, Width = 230, Thickness = 78, SearchType = SearchType.Production, CreatedAfterDate = new DateTime(2017, 1, 1), CreatedBeforeDate = new DateTime(2017, 12, 31) },
                $"select COUNT(id) as RollCount, Type, Width, Thickness, sum(Length) as TotalLength, sum(WeightReal) as TotalWeight, min(Createdon) as FirstDateCreated, max(createdon) as LastDateCreated from dbo.rolls where type = 'o' and width = 230 and thickness = 78 and CreatedOn >= '2017-01-01' and createdon <= '2017-12-31' group by Type, Width, Thickness");

            yield return new TestCaseData(
                new SearchCriteria() { RollType = RollType.Tube, Width = 1930, Thickness = 880, SearchType = SearchType.Consumption, CreatedAfterDate = new DateTime(2017, 1, 3), CreatedBeforeDate = new DateTime(2017, 12, 31) },
                $"select COUNT(id) as RollCount, Type, Width, Thickness, sum(Length) as TotalLength, sum(WeightReal) as TotalWeight, min(Createdon) as FirstDateCreated, max(createdon) as LastDateCreated from dbo.rolls where type = 'o' and width = 1930 and thickness = 880 and consumedon is not null and consumedon >= '2017-01-03' and consumedon <= '2017-12-31' group by Type, Width, Thickness");
        }
    }
}
