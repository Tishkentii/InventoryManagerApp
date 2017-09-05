using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerDataAccess.Internal
{
    internal class DataProvider
    {
        internal static DataTable ExecuteAccessQuery(string query, string connectionString)
        {
            using (var connection = new OleDbConnection(connectionString))
            using (var adapter = new OleDbDataAdapter(query, connection))
            {
                connection.Open();
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        internal static DataTable ExecuteSqlQuery(string queryString, string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var adapter = new SqlDataAdapter(queryString, connection))
            {
                connection.Open();
                var table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        internal static object ExecuteSqlScalar(string queryString, string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(queryString, connection))
            {
                connection.Open();
                return command.ExecuteScalar();
            }
        }

        internal static void ExecuteSqlNonQuery(string commandString, string connectionString)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(commandString, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        internal static void SqlBulkCopyData(string destinationTableName, DataTable data, Dictionary<string, string> mappings, string connectionString)
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
