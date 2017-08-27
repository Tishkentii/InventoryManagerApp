using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagerDataAccess;
using InventoryManagerModel;

namespace InventoryManagerServices
{
    public class RollService
    {
        readonly IDbRepository _sqlRepository;
        readonly IDbRepository _accessRepository;

        readonly CommandStringHelper _commandHelper;

        public RollService(IDbRepository sqlRepository, IDbRepository accessRepository)
        {
            _sqlRepository = sqlRepository;
            _accessRepository = accessRepository;

            _commandHelper = new CommandStringHelper();
        }

        public async Task SynchronizeDatabasesAsync()
        {
            var id = await _sqlRepository.ExecuteScalarAsync(_commandHelper.LastCreatedRollIDCommandString).ConfigureAwait(false);
            DataTable accessData = await Task.Run(() => _accessRepository.ExecuteQuery(_commandHelper.GetSynchonizationCommandString((int)id))).ConfigureAwait(false);
            await _sqlRepository.BulkCopyDataAsync("Rolls", accessData, _commandHelper.AccessToSqlColumnMapping).ConfigureAwait(false);
        }

        public async Task<ICollection<RollSummary>> GetRollsSummaryAccordingToCriteriaAsync(SearchCriteria criteria)
        {
            //var rollSummaryRawData = await Task.Run(() => _sqlRepository.ExecuteQuery(_commandHelper.GetRollSummaryCommandString(criteria)));
            var list = new HashSet<RollSummary>();
            //foreach (DataRow row in rollSummaryRawData.Rows)
            //{
            //    list.Add(new RollSummary(row));
            //}
            //Parallel.ForEach(rollSummaryRawData.AsEnumerable(), (rawData =>
            //{
            //    lock (list)
            //        list.Add(new RollSummary(rawData));
            //}));
            return list;
        }

        public async Task<ICollection<Roll>> GetRollDetailsFromSummaryAsync(RollSummary summary, SearchType searchType)
        {
            //var data = await Task.Run(() => _sqlRepository.ExecuteQuery(_commandHelper.GetSummaryDetailsCommandString(summary, searchType)));
            var list = new HashSet<Roll>();
            //foreach (DataRow row in data.Rows)
            //{
            //    list.Add(new Roll(row));
            //}
            return list;
        }

    }
}
