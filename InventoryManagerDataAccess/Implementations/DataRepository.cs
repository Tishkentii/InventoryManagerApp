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
            if (String.IsNullOrEmpty(sqlConnectionString) || String.IsNullOrEmpty(accessConnectionString))
                throw new ArgumentException("Invalid connection strings");

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

        public ICollection<Roll> GetRollDetails(SearchType searchType, int sizeID)
        {
            var sqlData = DataProvider.ExecuteSqlQuery(CommandStringHelper.GetSummaryDetailsCommandString(searchType, sizeID), _sqlConnectionString);
            var collection = new HashSet<Roll>();
            foreach (DataRow row in sqlData.Rows)
            {
                collection.Add(ObjectFactory.CreateRoll(row));
            }
            return collection;
        }

        public void SynchronizeAccessAndSqlDatabases()
        {
            var lastestRollId = DataProvider.ExecuteSqlScalar(CommandStringHelper.LastCreatedRollIDCommandString, _sqlConnectionString);
            DataTable accessData = DataProvider.ExecuteAccessQuery(CommandStringHelper.GetLatestAccessDataCommandString((int)lastestRollId), _accessConnectionString);
            DataProvider.SqlBulkCopyData("RollSync", accessData, CommandStringHelper.AccessToSqlColumnMapping, _sqlConnectionString);

            DataProvider.ExecuteSqlNonQuery("exec dbo.SyncRolls", _sqlConnectionString);
        }
    }
}
