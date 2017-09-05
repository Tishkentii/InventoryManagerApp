using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagerDataAccess.Interfaces;
using InventoryManagerDataAccess.Internal;
using InventoryManagerModel;
using InventoryManagerModel.DTOs;
using InventoryManagerModel.Entities;

namespace InventoryManagerDataAccess.Implementations
{
    public class DataRepository : IDataRepository
    {
        readonly string _sqlConnectionString, _accessConnectionString;

        public DataRepository(string sqlConnectionString, string accessConnectionString)
        {
            _sqlConnectionString = sqlConnectionString;
            _accessConnectionString = accessConnectionString;
        }

        public ICollection<RollSummary> GetRollSummary(SearchCriteria searchCriteria)
        {
            var sqlData = DataProvider.ExecuteSqlQuery(CommandStringHelper.GetRollSummaryCommandString(searchCriteria), _sqlConnectionString);
            var collection = new HashSet<RollSummary>();
            foreach (DataRow row in sqlData.Rows)
            {
                collection.Add(ObjectFactory.CreateRollSummary(row));
            }
            return collection;
        }

        public ICollection<Roll> GetRollDetails(SearchType searchType, RollSummary summary)
        {
            var sqlData = DataProvider.ExecuteSqlQuery(CommandStringHelper.GetSummaryDetailsCommandString(searchType, summary), _sqlConnectionString);
            var collection = new HashSet<Roll>();
            foreach (DataRow row in sqlData.Rows)
            {
                collection.Add(ObjectFactory.CreateRoll(row));
            }
            return collection;
        }

        public void SynchronizeAccessAndSqlDatabases()
        {
            var id = DataProvider.ExecuteSqlScalar(CommandStringHelper.LastCreatedRollIDCommandString, _sqlConnectionString);
            DataTable accessData = DataProvider.ExecuteAccessQuery(CommandStringHelper.GetLatestAccessDataCommandString((int)id), _accessConnectionString);
            DataProvider.SqlBulkCopyData("Rolls", accessData, CommandStringHelper.AccessToSqlColumnMapping, _sqlConnectionString);
        }
    }
}
