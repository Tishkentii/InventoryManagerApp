using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerDataAccess
{
    public interface IDbRepository
    {
        DataTable ExecuteQuery(string queryString);

        Task<object> ExecuteScalarAsync(string queryString);
        Task ExecuteNonQueryAsync(string commandString);
        Task BulkCopyDataAsync(string destinationTableName, DataTable data, Dictionary<string, string> mappings);
    }
}
