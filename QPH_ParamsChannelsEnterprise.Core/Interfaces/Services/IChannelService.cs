using QPH_ParamsChannelsEnterprise.Core.CustomEntities;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using Sieve.Models;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Core.Interfaces.Services
{
    public interface IChannelService
    {
        Task<ChannelDTO> GetChannel(long id);
        Task InsertChannel(ChannelDTO newChannel);
        Task<bool> UpdateChannel(ChannelDTO updatedChannel);
        Task<bool> DeleteChannel(int id);
        PagedList<ChannelDTO> GetAllChannels(SieveModel sieveModel);
    }
}
