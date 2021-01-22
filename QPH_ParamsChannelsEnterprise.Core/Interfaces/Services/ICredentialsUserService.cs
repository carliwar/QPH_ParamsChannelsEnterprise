using QPH_ParamsChannelsEnterprise.Core.CustomEntities;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using Sieve.Models;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Core.Interfaces.Services
{
    public interface ICredentialsUserService  
    {        
        Task<CredentialsUserDTO> GetCredentialsUser(int id);
        Task InsertCredentialsUser(CredentialsUserDTO newCredentialsUser);
        Task<bool> UpdateCredentialsUser(CredentialsUserDTO updatedCredentialsUser);
        Task<bool> DeleteCredentialsUser(int id);
        PagedList<CredentialsUserDTO> GetAllCredentialsUsers(SieveModel sieveModel);
    }
}
