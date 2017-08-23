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

        public RollService(IDbRepository sqlRepository, IDbRepository accessRepository)
        {
            _sqlRepository = sqlRepository;
            _accessRepository = accessRepository;
        }

        public async Task SynchronizeDatabasesAsync()
        {
            var id = await _sqlRepository.ExecuteScalarAsync(CommandStringHelper.LastCreatedRollIDCommandString).ConfigureAwait(false);
            DataTable accessData = await Task.Run(() => _accessRepository.ExecuteQuery(CommandStringHelper.GetSynchonizationCommandString((int)id))).ConfigureAwait(false);
            await _sqlRepository.BulkCopyDataAsync("Rolls", accessData, CommandStringHelper.AccessToSqlColumnMapping).ConfigureAwait(false);
        }

        public async Task<IEnumerable<RollSummary>> GetRollsSummaryAccordingToCriteriaAsync(SearchCriteria criteria)
        {
            var rollSummaryRawData = await Task.Run(() => _sqlRepository.ExecuteQuery(CommandStringHelper.GetRollSummaryCommandString(criteria)));
            var list = new List<RollSummary>();
            foreach (DataRow row in rollSummaryRawData.Rows)
            {
                list.Add(new RollSummary(row));
            }
            //Parallel.ForEach(rollSummaryRawData.AsEnumerable(), (rawData =>
            //{
            //    lock (list)
            //        list.Add(new RollSummary(rawData));
            //}));
            return list;
        }

        public IEnumerable<Roll> GetRollDetailsFromSummary(RollSummary summary)
        {
            yield return new Roll(1);
            yield return new Roll(2);
            yield return new Roll(3);
            yield return new Roll(4);
            yield return new Roll(5);
        }

    }
}
