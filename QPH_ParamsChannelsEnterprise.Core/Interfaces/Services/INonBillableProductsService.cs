using QPH_ParamsChannelsEnterprise.Core.CustomEntities;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using Sieve.Models;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Core.Interfaces.Services
{
    public interface INonBillableProductsService
    {
        Task<NonBillableProductsDTO> GetNonBillableProduct(int id);
        Task InsertNonBillableProduct(NonBillableProductsDTO newNonBillableProduct);
        Task<bool> UpdateNonBillableProduct(NonBillableProductsDTO updatedNonBillableProduct);
        Task<bool> DeleteNonBillableProduct(int id);
        PagedList<NonBillableProductsDTO> GetAllNonBillableProducts(SieveModel sieveModel);
        PagedList<NonBillableProductsDTO> GetAllActiveNonBillableProducts(SieveModel sieveModel);
        Task<NonBillableProductsInfoDTO> GetNonBillableProduct(string code, string channel);
    }
}
