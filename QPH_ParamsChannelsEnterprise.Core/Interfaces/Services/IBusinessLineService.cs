using QPH_ParamsChannelsEnterprise.Core.CustomEntities;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using Sieve.Models;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Core.Interfaces.Services
{
    public interface IBusinessLineService
    {
        Task<BusinessLineDTO> GetBusinessLine(int id);
        Task InsertBusinessLine(BusinessLineDTO newBusinessLine);
        Task<bool> UpdateBusinessLine(BusinessLineDTO updatedBusinessLine);
        Task<bool> DeleteBusinessLine(int id);
        PagedList<BusinessLineDTO> GetAllBusinessLines(SieveModel sieveModel);
    }
}
