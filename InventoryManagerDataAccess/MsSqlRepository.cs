using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerDataAccess
{
    public class MsSqlRepository
    {
        readonly string connectionString;

        public MsSqlRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DataTable ExecuteQuery(string query)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var adapter = new SqlDataAdapter(query, connection))
            {
                connection.Open();
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public void ExecuteNonQuery(string commandString)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(commandString, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void BulkCopyData(string destinationTableName, DataTable data, Dictionary<string, string> mappings)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var bulkCopy = new SqlBulkCopy(connection))
            {
                foreach (var pair in mappings)
                {
                    var mapping = new SqlBulkCopyColumnMapping(pair.Key, pair.Value);
                    bulkCopy.ColumnMappings.Add(mapping);
                }
                connection.Open();
                bulkCopy.DestinationTableName = destinationTableName; // Rolls
                bulkCopy.WriteToServer(data);
            }
        }
    }
}
