using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagerModel;
using InventoryManagerModel.Entities;
using NUnit.Framework;

namespace InventoryManagerAppTests.TestData
{
    public class ModelTestData
    {
        public static IEnumerable<TestCaseData> RollSize_ValidData
        {
            get
            {
                yield return new TestCaseData(1, RollType.Film, 440, 70);
                yield return new TestCaseData(2, RollType.Tube, 480, 120);
            }
        }

        public static IEnumerable<TestCaseData> RollSize_InvalidData
        {
            get
            {
                yield return new TestCaseData(0, RollType.Film, 440, 70);
                yield return new TestCaseData(-5, RollType.Tube, 480, 120);
                yield return new TestCaseData(2, RollType.Tube, 0, 120);
                yield return new TestCaseData(3, RollType.Tube, -10, 120);
                yield return new TestCaseData(4, RollType.Tube, 120, 0);
                yield return new TestCaseData(4, RollType.Tube, 120, -10);
            }
        }

        public static IEnumerable<TestCaseData> Roll_ValidData
        {
            get
            {
                yield return new TestCaseData(1, new RollSize(1, RollType.Film, 440, 70), "testerman", 505.42, 39.82, "testernotes", DateTime.Today, null);
                yield return new TestCaseData(2, new RollSize(1, RollType.Film, 440, 70), "testerman", 505.42, 39.82, "testernotes", DateTime.Today, DateTime.Today.AddDays(1));
            }
        }

        public static IEnumerable<TestCaseData> Roll_InvalidData
        {
            get
            {
                yield return new TestCaseData(0, new RollSize(1, RollType.Film, 440, 70), "testerman", 505.42, 39.82, "testernotes", DateTime.Today, null);
                yield return new TestCaseData(-9, new RollSize(1, RollType.Film, 440, 70), "testerman", 505.42, 39.82, "testernotes", DateTime.Today, DateTime.Today.AddDays(1));
                yield return new TestCaseData(2, new RollSize(1, RollType.Film, 440, 70), null, 505.42, 39.82, "testernotes", DateTime.Today, null);
                yield return new TestCaseData(3, new RollSize(1, RollType.Film, 440, 70), "testerman", 0, 39.82, "testernotes", DateTime.Today, null);
                yield return new TestCaseData(4, new RollSize(1, RollType.Film, 440, 70), "testerman", -505, 39.82, "testernotes", DateTime.Today, null);
                yield return new TestCaseData(5, new RollSize(1, RollType.Film, 440, 70), "testerman", 505.42, 0, "testernotes", DateTime.Today, null);
                yield return new TestCaseData(6, new RollSize(1, RollType.Film, 440, 70), "testerman", 505.42, -39.82, "testernotes", DateTime.Today, null);
                yield return new TestCaseData(7, new RollSize(1, RollType.Film, 440, 70), "testerman", 505.42, 39.82, null, DateTime.Today, null);
                yield return new TestCaseData(8, new RollSize(1, RollType.Film, 440, 70), "testerman", 505.42, 39.82, "testernotes", DateTime.Today, DateTime.Today.AddDays(-1));
            }
        }

        public static IEnumerable<TestCaseData> Roll_NullData
        {
            get
            {
                yield return new TestCaseData(1, null, "testerman", 505.42, 39.82, "testernotes", DateTime.Today, null);
            }
        }

        public static IEnumerable<TestCaseData> RollSummary_ValidData
        {
            get
            {
                yield return new TestCaseData(new RollSize(1, RollType.Film, 440, 70), 10, 6120.55, 451.4, DateTime.Today, DateTime.Today.AddDays(5));
                yield return new TestCaseData(new RollSize(2, RollType.Tube, 220, 100), 0, 0, 0, null, null);
            }
        }

        public static IEnumerable<TestCaseData> RollSummary_InvalidData
        {
            get
            {
                yield return new TestCaseData(new RollSize(1, RollType.Film, 440, 70), -10, 6120.55, 451.4, DateTime.Today, DateTime.Today.AddDays(5));
                yield return new TestCaseData(new RollSize(1, RollType.Film, 440, 70), 1, 0, 451.4, DateTime.Today, DateTime.Today.AddDays(5));
                yield return new TestCaseData(new RollSize(1, RollType.Film, 440, 70), 2, -6, 451.4, DateTime.Today, DateTime.Today.AddDays(5));
                yield return new TestCaseData(new RollSize(1, RollType.Film, 440, 70), 3, 6120.55, 0, DateTime.Today, DateTime.Today.AddDays(5));
                yield return new TestCaseData(new RollSize(1, RollType.Film, 440, 70), 4, 6120.55, -451.4, DateTime.Today, DateTime.Today.AddDays(5));
                yield return new TestCaseData(new RollSize(1, RollType.Film, 440, 70), 0, 6120.55, 451.4, DateTime.Today, DateTime.Today.AddDays(5));
                yield return new TestCaseData(new RollSize(1, RollType.Film, 440, 70), 6, 0, 0, DateTime.Today, DateTime.Today.AddDays(5));
                yield return new TestCaseData(new RollSize(1, RollType.Film, 440, 70), 7, 6120.55, 451.4, DateTime.Today, DateTime.Today.AddDays(-5));
                yield return new TestCaseData(new RollSize(1, RollType.Film, 440, 70), 8, 6120.55, 451.4, null, null);
            }
        }

        public static IEnumerable<TestCaseData> RollSummary_NullData
        {
            get
            {
                yield return new TestCaseData(null, 10, 6120.55, 451.4, DateTime.Today, DateTime.Today.AddDays(5));
            }
        }

    }
}
