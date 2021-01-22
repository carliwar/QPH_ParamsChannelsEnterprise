using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;
using QPH_ParamsChannelsEnterprise.Core.Interfaces.Repositories;
using QPH_ParamsChannelsEnterprise.Infrastructure.Data;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Repositories
{
    class EnterpriseCredentialsRepository : AdministrationSwitchBaseRepository<EnterpriseCredentials>, IEnterpriseCredentialsRepository
    {
        public EnterpriseCredentialsRepository(AdministrationSwitchContext context) : base(context) { }
    }
}
