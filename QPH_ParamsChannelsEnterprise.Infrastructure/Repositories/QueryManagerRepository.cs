using Microsoft.EntityFrameworkCore;
using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;
using QPH_ParamsChannelsEnterprise.Core.Interfaces.Repositories;
using QPH_ParamsChannelsEnterprise.Infrastructure.Data;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Repositories
{
    public class QueryManagerRepository : AdministrationSwitchBaseRepository<QueryManager>, IQueryManagerRepository
    {
        public QueryManagerRepository(AdministrationSwitchContext context) : base(context) { }
        public async Task<QueryManager> GetByCode(string code, int? oldID) => await _entities.FirstOrDefaultAsync(t => t.Code == code && t.IDQueryManager != oldID);
    }
}
