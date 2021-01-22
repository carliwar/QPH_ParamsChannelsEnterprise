using QPH_ParamsChannelsEnterprise.Core.CustomEntities;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using Sieve.Models;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Core.Interfaces.Services
{
    public interface IEnterpriseService
    {
        Task<EnterpriseDTO> GetEnterprise(int id);
        Task InsertEnterprise(EnterpriseDTO newEnterprise);
        Task<bool> UpdateEnterprise(EnterpriseDTO updatedEnterprise);
        Task<bool> DeleteEnterprise(int id);
        PagedList<EnterpriseDTO> GetAllEnterprises(SieveModel sieveModel);
    }
}
