using QPH_ParamsChannelsEnterprise.Core.Entities.SwitchAtiscode;
using QPH_ParamsChannelsEnterprise.Core.Interfaces.Repositories;
using QPH_ParamsChannelsEnterprise.Infrastructure.Data;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Repositories
{
    public class AtisLogTranRepository : SwitchAtiscodeBaseRepository<AtisLogTran>, IAtisLogTranRepository
    {
        public AtisLogTranRepository(SwitchAtiscodeContext context) : base(context) { }
    }
}
