using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;
using QPH_ParamsChannelsEnterprise.Core.Interfaces.Repositories;
using QPH_ParamsChannelsEnterprise.Infrastructure.Data;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Repositories
{
    public class ChannelNonBillableProductsRepository : AdministrationSwitchBaseRepository<ChannelNonBillableProducts>, IChannelNonBillableProductsRepository
    {
        public ChannelNonBillableProductsRepository(AdministrationSwitchContext context) : base(context) { }
    }
}
