using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Core.Interfaces.Repositories
{
    public interface IAdministrationSwitchProceduresRepository
    {
        Task<GetNonBilllableProductsResult> GetNonBillableProducts(string code, string channel);        
        Task<List<ChannelEnterpriseInfo>> GetChannelEnterpriseViewResult(string channel);
        Task<List<FinancialSizingViewResults>> GetFinancialSizingViewResults();
        Task<QueryManager> GetQueryManagerResult(string code);

    }
}
