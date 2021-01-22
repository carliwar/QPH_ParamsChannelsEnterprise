using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;
using QPH_ParamsChannelsEnterprise.Core.Interfaces.Repositories;
using QPH_ParamsChannelsEnterprise.Infrastructure.Data;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Repositories
{
    public class EnterpriseRepository : AdministrationSwitchBaseRepository<Enterprise>, IEnterpriseRepository
    {
        public EnterpriseRepository(AdministrationSwitchContext context) : base(context) { }
    }
}
