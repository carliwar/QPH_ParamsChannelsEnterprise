using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;
using QPH_ParamsChannelsEnterprise.Core.Interfaces.Repositories;
using QPH_ParamsChannelsEnterprise.Infrastructure.Data;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Repositories
{
    public class CredentialsUserRepository : AdministrationSwitchBaseRepository<CredentialsUser>, ICredentialsUserRepository
    {
        public CredentialsUserRepository(AdministrationSwitchContext context) : base(context) { }
    }
}
