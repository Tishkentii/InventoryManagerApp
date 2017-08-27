using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagerModel;
using NUnit.Framework;

namespace InventoryManagerAppTests.ServicesTests.TestData
{
    public class RollServiceData
    {
        public static IEnumerable<TestCaseData> GetRollsSummaryAccordingToCriteria_CorrectData()
        {
            var searchInput = new SearchCriteria();

            var testDataTable = new DataTable();
            testDataTable.Columns.Add("RollCount");
            testDataTable.Columns.Add("Width");
            testDataTable.Columns.Add("Thickness");
            testDataTable.Columns.Add("TotalLength");
            testDataTable.Columns.Add("TotalWeight");
            testDataTable.Columns.Add("LastDateCreated");
            testDataTable.Columns.Add("FirstDateCreated");
            var row1 = testDataTable.NewRow();
            row1[0] = 10;
            row1[1] = 120;
            row1[2] = 70;
            row1[3] = 505.65;
            row1[4] = 43.51;
            row1[5] = new DateTime(2017, 8, 5);
            row1[6] = new DateTime(2017, 1, 5);
            testDataTable.Rows.Add(row1);
            var row2 = testDataTable.NewRow();
            row2[0] = 12;
            row2[1] = 100;
            row2[2] = 90;
            row2[3] = 515.65;
            row2[4] = 40.51;
            row2[5] = new DateTime(2017, 3, 1);
            row2[6] = new DateTime(2017, 2, 19);
            testDataTable.Rows.Add(row2);

            var summary = new List<RollSummary>
            {
                new RollSummary(RollType.Tube, 10, 120, 70, 505.65, 43.51, new DateTime(2017, 8, 5), new DateTime(2017, 1, 5)),
                new RollSummary(RollType.Tube, 12, 100, 90, 515.65, 40.51, new DateTime(2017, 3, 1), new DateTime(2017, 2, 19))

            };

            yield return new TestCaseData(searchInput, testDataTable, summary);

        }

    }
}
