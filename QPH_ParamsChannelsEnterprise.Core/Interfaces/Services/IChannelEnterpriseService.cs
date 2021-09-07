using QPH_ParamsChannelsEnterprise.Core.CustomEntities;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;
using Sieve.Models;
using Sieve.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Core.Interfaces.Services
{
    public interface IChannelEnterpriseService
    {
        ISieveProcessor SieveProcessor { get; set; }
        Task<List<ChannelEnterpriseInfoDTO>> GetChannelEnterprisesInfo(string channel);
        PagedListSieve<ChannelEnterpriseInfo> GetAllChannelsEnterprise(SieveModel sieveModel);
        Task<ChannelEnterpriseInfoDTO> GetChannelEnterpriseByDocumentNumber(string documentNumber, string proveedor);
        Task<NonBillableProductsInfoDTO> GetNonBillableProducts(string code, string channel);
        Task<bool> IsNonBillableProduct(string code, string channel);
        Task<bool> UpdateChannelEnterprise(ChannelEnterpriseDTO channelEnterpriseDTO);
        Task InsertChannelEnterprise(ChannelEnterpriseDTO newChannelEnterprise);
        Task DeleteChannelEnterprise(int id);
    }
}
