using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagerDataAccess.Implementations;
using InventoryManagerTests.TestData;
using NUnit.Framework;

namespace InventoryManagerAppTests.Tests
{
    [TestFixture]
    public class DataAccessTests
    {
        [TestCaseSource(typeof(DataAccessTestData), "DataRepository_InvalidParams")]
        public void DataRepositoryConstructor_InvalidParams_ThrowsArgument(string sqlConStr, string accessConStr)
        {
            Assert.Throws<ArgumentException>(() => new DataRepository(sqlConStr, accessConStr));
        }
    }
}
