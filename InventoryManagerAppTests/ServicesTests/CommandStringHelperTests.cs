using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagerModel;
using InventoryManagerServices;
using NUnit.Framework;

namespace InventoryManagerAppTests.ServicesTests
{
    [TestFixture]
    public class CommandStringHelperTests
    {
        [TestCaseSource(typeof(CommandStringHelperData), "GetRollSummaryCommandString_AlwaysCorrect_TestData")]
        public void GetRollSummaryCommandString_Always_ReturnsExpected(SearchCriteria input, string expected)
        {
            var sut = new CommandStringHelper();
            string actual = sut.GetRollSummaryCommandString(input).ToLower();
            Assert.That(actual, Is.EqualTo(expected.ToLower()));
        }

        [Test]
        public void GetRollSummaryCommandString_WhenCriteriaNull_ThrowsArgumentNull()
        {
            var sut = new CommandStringHelper();
            Assert.Throws<ArgumentNullException>(() => sut.GetRollSummaryCommandString(null), "criteria");
        }
    }
}
