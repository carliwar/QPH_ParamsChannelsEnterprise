using QPH_ParamsChannelsEnterprise.Core.CustomEntities;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using Sieve.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Core.Interfaces.Services
{
    public interface IParametersService
    {
        Task<ParametersDTO> GetParameter(int id);
        Task InsertParameter(ParametersDTO newChannel);
        Task<bool> UpdateParameter(ParametersDTO updatedChannel);
        Task<bool> DeleteParameter(int id);
        PagedList<ParametersDTO> GetAllParameters(SieveModel sieveModel);
        List<DocumentsTypes> GetDocumentsTypesAsync();
    }
}
