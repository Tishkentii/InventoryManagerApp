using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagerDataAccess.Interfaces;
using InventoryManagerModel;
using InventoryManagerModel.DTOs;
using InventoryManagerModel.Entities;

namespace InventoryManagerServices
{
    public class BusinessService
    {
        readonly IDataRepository _dataRepository;

        public BusinessService(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public async Task SynchronizeDatabasesAsync()
        {
            await Task.Run(() => _dataRepository.SynchronizeAccessAndSqlDatabases()).ConfigureAwait(false);
        }

        public async Task<ICollection<RollSummary>> GetRollsSummaryAsync(SearchCriteria criteria)
        {
            return await Task.Run(() => _dataRepository.GetRollSummary(criteria)).ConfigureAwait(false);
        }

        public async Task<ICollection<Roll>> GetRollDetailsAsync(SearchType searchType, RollSummary summary)
        {
            return await Task.Run(() => _dataRepository.GetRollDetails(searchType, summary)).ConfigureAwait(false);
        }

    }
}
