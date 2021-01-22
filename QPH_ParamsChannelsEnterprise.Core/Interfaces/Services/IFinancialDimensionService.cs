using QPH_ParamsChannelsEnterprise.Core.CustomEntities;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using Sieve.Models;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Core.Interfaces.Services
{
    public interface IFinancialDimensionService
    {
        Task<FinancialDimensionDTO> GetFinancialDimension(int id);
        Task InsertFinancialDimension(FinancialDimensionDTO newFinancialDimension);
        Task<bool> UpdateFinancialDimension(FinancialDimensionDTO updatedFinancialDimension);
        Task<bool> DeleteFinancialDimension(int id);
        PagedList<FinancialDimensionDTO> GetAllFinancialDimensions(SieveModel sieveModel);
    }
}
