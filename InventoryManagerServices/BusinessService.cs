using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagerDataAccess.Interfaces;
using InventoryManagerModel;
using InventoryManagerModel.DTOs;
using InventoryManagerModel.Entities;
using InventoryManagerServices.Internal;

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
            return await Task.Run(() => _dataRepository.GetRollDetails(searchType, summary.RollSize.SizeID)).ConfigureAwait(false);
        }

        public void SaveSummaries(ICollection<RollSummary> summaries, string fileName, bool openAfter)
        {
            var csvText = CSVService.ConvertSummariesToCSV(summaries);
            var path = DirectoryService.SaveToFile(csvText, $"{fileName}.csv");
            if (openAfter)
                DirectoryService.OpenFile(path);
        }

        public void OpenSaveDestinationFoler()
        {
            DirectoryService.OpenSaveDestinationFolder();
        }
    }
}
