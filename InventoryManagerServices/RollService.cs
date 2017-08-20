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
        readonly MsSqlRepository _sqlRepository;
        readonly MsAccessRepository _accessRepository;

        public RollService(MsSqlRepository sqlRepository, MsAccessRepository accessRepository)
        {
            _sqlRepository = sqlRepository;
            _accessRepository = accessRepository;
        }

        public void SynchronizeDatabases()
        {
            int id = GetLastCreatedRollID();
            var accessData = _accessRepository.ExecuteQuery(CommandStringHelper.GetSynchonizationCommandString(id));
            _sqlRepository.BulkCopyData("Rolls", accessData, CommandStringHelper.AccessToSqlColumnMapping);
        }

        public IEnumerable<RollSummary> GetRollsSummaryAccordingToCriteria(SearchCriteria criteria)
        {
            yield return new RollSummary(10, 200, 0.07, 100.12, 4381, DateTime.Now, DateTime.Now);
            yield return new RollSummary(12, 100, 0.07, 70.12, 481, DateTime.Now, DateTime.Now);
            yield return new RollSummary(30, 400, 0.12, 100.12, 4381, DateTime.Now, DateTime.Now);
            yield return new RollSummary(9, 220, 0.09, 700.12, 1381, DateTime.Now, DateTime.Now);
            yield return new RollSummary(5, 440, 0.12, 120.12, 3381, DateTime.Now, DateTime.Now);

        }

        public IEnumerable<Roll> GetRollDetailsFromSummary(RollSummary summary)
        {
            yield return new Roll(1);
            yield return new Roll(2);
            yield return new Roll(3);
            yield return new Roll(4);
            yield return new Roll(5);
        }

        int GetLastCreatedRollID()
        {
            throw new NotImplementedException();
        }
    }
}
