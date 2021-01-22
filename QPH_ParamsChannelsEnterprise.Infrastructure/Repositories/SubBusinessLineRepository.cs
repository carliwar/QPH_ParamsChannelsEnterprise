using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;
using QPH_ParamsChannelsEnterprise.Core.Interfaces.Repositories;
using QPH_ParamsChannelsEnterprise.Infrastructure.Data;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Repositories
{
    public class SubBusinessLineRepository : AdministrationSwitchBaseRepository<SubBusinessLine>, ISubBusinessLineRepository
    {
        public SubBusinessLineRepository(AdministrationSwitchContext context) : base(context) { }
    }
}
