using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagerAppTests.ServicesTests.TestData;
using InventoryManagerDataAccess;
using InventoryManagerModel;
using InventoryManagerServices;
using Moq;
using NUnit.Framework;

namespace InventoryManagerAppTests.ServicesTests
{
    [TestFixture]
    public class RollServiceTests
    {
        Mock<IDbRepository> _mockSqlRepository;

        [TestCaseSource(typeof(RollServiceData), "GetRollsSummaryAccordingToCriteria_CorrectData")]
        public async Task GetRollsSummaryAccordingToCriteria_Always_ReturnsExpected(SearchCriteria input, DataTable tempResult, IEnumerable<RollSummary> expected)
        {
            _mockSqlRepository = new Mock<IDbRepository>(MockBehavior.Strict);
            _mockSqlRepository.Setup(s => s.ExecuteQuery(CommandStringHelper.GetRollSummaryCommandString(input))).Returns(tempResult);

            var sut = new RollService(_mockSqlRepository.Object, _mockSqlRepository.Object);
            var actual = await sut.GetRollsSummaryAccordingToCriteriaAsync(input);
            Assert.That(actual, Is.EqualTo(expected));
        }

        //[Test]
        //public void GetRollsSummaryAccordingToCriteria_WhenCriteriaNull_ThrowsArgumentNull()
        //{
        //    SearchCriteria input = null;
        //    _mockSqlRepository = new Mock<IDbRepository>(MockBehavior.Strict);
        //    _mockSqlRepository.Setup(s => s.ExecuteQuery(CommandStringHelper.GetRollSummaryCommandString(input))).Returns(() => null);

        //    var sut = new RollService(_mockSqlRepository.Object, _mockSqlRepository.Object);
        //    Assert.Throws<ArgumentNullException>(async () => await sut.GetRollsSummaryAccordingToCriteriaAsync(input));
        //}
    }
}
