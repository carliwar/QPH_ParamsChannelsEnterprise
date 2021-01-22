using Microsoft.EntityFrameworkCore;
using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;
using QPH_ParamsChannelsEnterprise.Core.Interfaces.Repositories;
using QPH_ParamsChannelsEnterprise.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Repositories
{
    public class AdministrationSwitchProceduresRepository : IAdministrationSwitchProceduresRepository
    {
        private readonly AdministrationSwitchContext _context;

        public AdministrationSwitchProceduresRepository(AdministrationSwitchContext context)
        {
            _context = context;
        }       

        public async Task<List<ChannelEnterpriseInfo>> GetChannelEnterpriseViewResult(string channel)
        {
            List<ChannelEnterpriseInfo> result = await _context.ChannelEnterpriseInfo.FromSqlRaw("exec GetChannel @Channel={0}", channel).ToListAsync();
            return result;
        }

        public async Task<GetNonBilllableProductsResult> GetNonBillableProducts(string code, string channel)
        {

            var spResult = await _context.GetNonBilllableProductsResult.FromSqlRaw("exec GetNonBillableProducts @Code={0}, @Channel={1}",
                 code, channel).ToListAsync();

            var result = spResult.FirstOrDefault();

            return result;
        }

        public async Task<List<FinancialSizingViewResults>> GetFinancialSizingViewResults()
        {
            List<FinancialSizingViewResults> result = await _context.FinancialSizingViewResults.FromSqlRaw("select * from vwFinancialSizing").ToListAsync();
            return result;
        }

        public async Task<QueryManager> GetQueryManagerResult(string code)
        {
            var spResult = await _context.QueryManager.FromSqlRaw("exec GetQuery @Code={0}", code).ToListAsync();

            QueryManager result = spResult.FirstOrDefault();

            return result;
        }
    }
}
