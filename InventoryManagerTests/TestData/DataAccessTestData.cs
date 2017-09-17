using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace InventoryManagerTests.TestData
{
    public class DataAccessTestData
    {
        public static IEnumerable<TestCaseData> DataRepository_InvalidParams
        {
            get
            {
                yield return new TestCaseData(null, "test");
                yield return new TestCaseData("", "test");
                yield return new TestCaseData("test", "");
                yield return new TestCaseData("test", null);
            }
        }
    }
}
