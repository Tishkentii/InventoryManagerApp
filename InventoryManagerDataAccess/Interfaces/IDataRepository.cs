using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagerModel;
using InventoryManagerModel.DTOs;
using InventoryManagerModel.Entities;

namespace InventoryManagerDataAccess.Interfaces
{
    public interface IDataRepository
    {
        ICollection<RollSummary> GetRollSummary(SearchCriteria searchCriteria);
        ICollection<Roll> GetRollDetails(SearchType searchType, RollSummary summary);

        void SynchronizeAccessAndSqlDatabases();
    }
}
