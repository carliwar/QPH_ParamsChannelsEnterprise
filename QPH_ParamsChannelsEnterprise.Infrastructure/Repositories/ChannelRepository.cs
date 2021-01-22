using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;
using QPH_ParamsChannelsEnterprise.Core.Interfaces.Repositories;
using QPH_ParamsChannelsEnterprise.Infrastructure.Data;

namespace QPH_ParamsChannelsEnterprise.Infrastructure.Repositories
{
    public class ChannelRepository : AdministrationSwitchBaseRepository<Channel>, IChannelRepository
    {
        public ChannelRepository(AdministrationSwitchContext context) : base(context) { }
    }
}
