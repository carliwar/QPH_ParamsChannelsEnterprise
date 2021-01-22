using QPH_ParamsChannelsEnterprise.Core.CustomEntities;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using Sieve.Models;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Core.Interfaces.Services
{
    public interface ISubBusinessLineService
    {
        Task<SubBusinessLineDTO> GetSubBusinessLine(int id);
        Task InsertSubBusinessLine(SubBusinessLineDTO newSubBusinessLine);
        Task<bool> UpdateSubBusinessLine(SubBusinessLineDTO updatedSubBusinessLine);
        Task<bool> DeleteSubBusinessLine(int id);
        PagedList<SubBusinessLineDTO> GetAllSubBusinessLines(SieveModel sieveModel);
    }
}
