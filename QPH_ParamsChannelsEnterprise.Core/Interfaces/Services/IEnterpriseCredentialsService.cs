using QPH_ParamsChannelsEnterprise.Core.CustomEntities;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using Sieve.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace QPH_ParamsChannelsEnterprise.Core.Interfaces.Services
{
    public interface IEnterpriseCredentialsService
    {
        Task<EnterpriseCredentialsDTO> GetEnterpriseCredentials(int id);
        Task InsertEnterpriseCredentials(EnterpriseCredentialsDTO newEnterpriseCredentials);
        Task InsertEnterpriseCredentialsList(List<EnterpriseCredentialsDTO> enterpriseCredentialsListsPostRequest);
        Task<bool> UpdateEnterpriseCredentials(EnterpriseCredentialsDTO updatedEnterpriseCredentials);
        Task<bool> DeleteEnterpriseCredentials(int id);
        PagedList<EnterpriseCredentialsDTO> GetAllEnterpriseCredentialss(SieveModel sieveModel);
    }
}
