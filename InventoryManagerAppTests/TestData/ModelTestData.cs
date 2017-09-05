using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagerModel;
using NUnit.Framework;

namespace InventoryManagerAppTests.TestData
{
    public class ModelTestData
    {
        public static IEnumerable<TestCaseData> Roll_ValidData
        {
            get
            {
                yield return new TestCaseData(1, RollType.Film, "menchev", 200, 70, 500.43, 35.78, "nothing", new DateTime(2017, 6, 8), new DateTime(2017, 8, 16));
                yield return new TestCaseData(2, RollType.Tube, "menchev", 300, 80, 620.43, 45.78, "nothing", new DateTime(2017, 6, 18), null);

            }
        }

        public static IEnumerable<TestCaseData> Roll_InvalidData
        {
            get
            {
                yield return new TestCaseData(0, RollType.Film, "menchev", 200, 70, 500.43, 35.78, "nothing", new DateTime(2017, 6, 8), null);
                yield return new TestCaseData(-10, RollType.Film, "menchev", 200, 70, 500.43, 35.78, "nothing", new DateTime(2017, 6, 8), null);
                yield return new TestCaseData(1, RollType.Film, "", 200, 70, 500.43, 35.78, "nothing", new DateTime(2017, 6, 8), null);
                yield return new TestCaseData(2, RollType.Film, null, 200, 70, 500.43, 35.78, "nothing", new DateTime(2017, 6, 8), null);
                yield return new TestCaseData(1, RollType.Film, "menchev", 0, 70, 500.43, 35.78, "nothing", new DateTime(2017, 6, 8), null);
                yield return new TestCaseData(1, RollType.Film, "menchev", -123, 70, 500.43, 35.78, "nothing", new DateTime(2017, 6, 8), null);
                yield return new TestCaseData(1, RollType.Film, "menchev", 200, 0, 500.43, 35.78, "nothing", new DateTime(2017, 6, 8), null);
                yield return new TestCaseData(1, RollType.Film, "menchev", 200, -234, 500.43, 35.78, "nothing", new DateTime(2017, 6, 8), null);
                yield return new TestCaseData(1, RollType.Film, "menchev", 200, 234, -500.43, 35.78, "nothing", new DateTime(2017, 6, 8), null);
                yield return new TestCaseData(1, RollType.Film, "menchev", 200, 120, 0, 35.78, "nothing", new DateTime(2017, 6, 8), null);
                yield return new TestCaseData(1, RollType.Film, "menchev", 200, 120, 46.7, 0, "nothing", new DateTime(2017, 6, 8), null);
                yield return new TestCaseData(1, RollType.Film, "menchev", 200, 120, 56.4, -35.78, "nothing", new DateTime(2017, 6, 8), null);
                yield return new TestCaseData(1, RollType.Film, "menchev", 200, 70, 500.43, 35.78, "nothing", new DateTime(2017, 9, 8), new DateTime(2017, 8, 16));
            }
        }

        public static IEnumerable<TestCaseData> RollSummary_ValidData
        {
            get
            {
                yield return new TestCaseData(RollType.Tube, 5, 200, 70, 5000.035, 349.44, new DateTime(2017, 4, 6), new DateTime(2017, 1, 1));
                yield return new TestCaseData(RollType.Film, 0, 200, 70, 0, 0, new DateTime(2017, 4, 6), new DateTime(2017, 1, 1));

            }
        }

        public static IEnumerable<TestCaseData> RollSummary_InvalidData
        {
            get
            {
                yield return new TestCaseData(RollType.Film, -15, 200, 70, 0, 0, new DateTime(2017, 4, 6), new DateTime(2017, 1, 1));
                yield return new TestCaseData(RollType.Film, 0, 0, 70, 0, 0, new DateTime(2017, 4, 6), new DateTime(2017, 1, 1));
                yield return new TestCaseData(RollType.Film, 0, -200, 70, 0, 0, new DateTime(2017, 4, 6), new DateTime(2017, 1, 1));
                yield return new TestCaseData(RollType.Film, 0, 200, 0, 0, 0, new DateTime(2017, 4, 6), new DateTime(2017, 1, 1));
                yield return new TestCaseData(RollType.Film, 0, 200, -70, 0, 0, new DateTime(2017, 4, 6), new DateTime(2017, 1, 1));
                yield return new TestCaseData(RollType.Film, 0, 200, 70, -10, 0, new DateTime(2017, 4, 6), new DateTime(2017, 1, 1));
                yield return new TestCaseData(RollType.Film, 0, 200, 70, 0, -10, new DateTime(2017, 4, 6), new DateTime(2017, 1, 1));
                yield return new TestCaseData(RollType.Film, 0, 200, 70, 0, 0, new DateTime(2017, 4, 6), new DateTime(2017, 8, 1));
                //yield return new TestCaseData(RollType.Film, 0, 200, 70, 50, 120, new DateTime(2017, 4, 6), new DateTime(2017, 1, 1));
                //yield return new TestCaseData(RollType.Film, 10, 200, 70, 0, 120, new DateTime(2017, 4, 6), new DateTime(2017, 1, 1));
                //yield return new TestCaseData(RollType.Film, 10, 200, 70, 10, 0, new DateTime(2017, 4, 6), new DateTime(2017, 1, 1));
            }
        }
    }
}
