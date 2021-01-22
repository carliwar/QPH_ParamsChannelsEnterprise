using QPH_ParamsChannelsEnterprise.Core.CustomEntities;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using Sieve.Models;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Core.Interfaces.Services
{
    public interface ICredentialsServerService 
    {        
        Task<CredentialsServerDTO> GetCredentialsServer(int id);
        Task InsertCredentialsServer(CredentialsServerDTO newCredentialServer);
        Task<bool> UpdateCredentialsServer(CredentialsServerDTO updatedCredentialsServerDTO);
        Task<bool> DeleteCredentialsServer(int id);
        PagedList<CredentialsServerDTO> GetAllCredentialsServers(SieveModel sieveModel);
    }
}
