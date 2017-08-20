using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagerDataAccess
{
    public class MsAccessRepository
    {
        readonly string connectionString;

        public MsAccessRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public DataTable ExecuteQuery(string query)
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
    }
}
