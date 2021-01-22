using QPH_ParamsChannelsEnterprise.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Core.Interfaces.Services
{
    public interface IChannelEnterpriseService
    {
        Task<List<ChannelEnterpriseInfoDTO>> GetChannelEnterprisesInfo(string channel);
        Task<ChannelEnterpriseInfoDTO> GetChannelEnterpriseByDocumentNumber(string documentNumber);
        Task<NonBillableProductsInfoDTO> GetNonBillableProducts(string code, string channel);
        Task<bool> IsNonBillableProduct(string code, string channel);
        Task<bool> UpdateChannelEnterprise(ChannelEnterpriseDTO channelEnterpriseDTO);
        Task InsertChannelEnterprise(ChannelEnterpriseDTO newChannelEnterprise);
        Task DeleteChannelEnterprise(int id);
    }
}
