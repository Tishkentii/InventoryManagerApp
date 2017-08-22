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
                new SearchCriteria() { RollType = RollType.Tube, Width = 200, Thickness = 70, SearchType = SearchType.Stock },
                "select * from dbo.rolls where type = 'o' and width = 200 and thickness = 70 and consumedon is null");

            yield return new TestCaseData(
                new SearchCriteria() { RollType = RollType.Film, Width = 1230, Thickness = 1880, SearchType = SearchType.Stock },
                "select * from dbo.rolls where type = 'i' and width = 1230 and thickness = 1880 and consumedon is null");

            yield return new TestCaseData(
                 new SearchCriteria() { RollType = RollType.Film, SearchType = SearchType.Stock },
                "select * from dbo.rolls where type = 'i' and consumedon is null");

            yield return new TestCaseData(
                new SearchCriteria() { RollType = RollType.Film, Thickness = 7880, SearchType = SearchType.Stock },
                "select * from dbo.rolls where type = 'i' and thickness = 7880 and consumedon is null");

            yield return new TestCaseData(
                new SearchCriteria() { RollType = RollType.Tube, Width = 230, Thickness = 78, SearchType = SearchType.Production, CreatedAfterDate = new DateTime(2017, 1, 1), CreatedBeforeDate = new DateTime(2017, 12, 31) },
                $"select * from dbo.rolls where type = 'o' and width = 230 and thickness = 78 and CreatedOn >= '01.01.2017 00:00:00' and createdon <= '31.12.2017 00:00:00'");

            yield return new TestCaseData(
                new SearchCriteria() { RollType = RollType.Film, Thickness = 80, SearchType = SearchType.Production, CreatedAfterDate = new DateTime(2017, 1, 2), CreatedBeforeDate = new DateTime(2017, 12, 31) },
                $"select * from dbo.rolls where type = 'i' and thickness = 80 and CreatedOn >= '02.01.2017 00:00:00' and createdon <= '31.12.2017 00:00:00'");

            yield return new TestCaseData(
                new SearchCriteria() { RollType = RollType.Tube, Width = 1930, Thickness = 880, SearchType = SearchType.Consumption, CreatedAfterDate = new DateTime(2017, 1, 3), CreatedBeforeDate = new DateTime(2017, 12, 31) },
                $"select * from dbo.rolls where type = 'o' and width = 1930 and thickness = 880 and consumedon is not null and consumedon >= '03.01.2017 00:00:00' and consumedon <= '31.12.2017 00:00:00'");

            yield return new TestCaseData(
                new SearchCriteria() { RollType = RollType.Film, Width = 8230, SearchType = SearchType.Consumption, CreatedAfterDate = new DateTime(2017, 1, 4), CreatedBeforeDate = new DateTime(2017, 12, 31) },
                $"select * from dbo.rolls where type = 'i' and width = 8230 and consumedon is not null and consumedon >= '04.01.2017 00:00:00' and consumedon <= '31.12.2017 00:00:00'");
        }
    }
}
