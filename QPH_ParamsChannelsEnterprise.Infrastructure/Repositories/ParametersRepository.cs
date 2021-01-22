using QPH_ParamsChannelsEnterprise.Core.Entities.SwitchAtiscode;
using QPH_ParamsChannelsEnterprise.Core.Interfaces.Repositories;
using QPH_ParamsChannelsEnterprise.Infrastructure.Data;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Repositories
{
    public class ParametersRepository : SwitchAtiscodeBaseRepository<Parameters>, IParametersRepository
    {
        public ParametersRepository(SwitchAtiscodeContext context) : base(context) { }
    }
}
