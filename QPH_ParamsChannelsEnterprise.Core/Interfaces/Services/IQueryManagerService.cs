using QPH_ParamsChannelsEnterprise.Core.CustomEntities;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using Sieve.Models;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Core.Interfaces.Services
{
    public interface IQueryManagerService    
    {
        Task<QueryManagerDTO> GetQueryManager(int id);
        Task<QueryManagerDTO> GetQueryManagerByCode(string code);
        Task InsertQueryManager(QueryManagerDTO newQueryManager);
        Task<bool> UpdateQueryManager(QueryManagerDTO updatedQueryManager);
        Task<bool> DeleteQueryManager(int id);
        PagedList<QueryManagerDTO> GetAllQueryManagers(SieveModel sieveModel);
    }
}
