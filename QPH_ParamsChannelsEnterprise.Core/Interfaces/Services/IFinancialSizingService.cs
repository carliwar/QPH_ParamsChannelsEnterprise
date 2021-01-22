using QPH_ParamsChannelsEnterprise.Core.CustomEntities;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using Sieve.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace QPH_ParamsChannelsEnterprise.Core.Interfaces.Services
{
    public interface IFinancialSizingService
    {
        Task<FinancialSizingDTO> GetFinancialSizing(int id);
        Task InsertFinancialSizing(FinancialSizingDTO newFinancialSizing);
        Task<bool> UpdateFinancialSizing(FinancialSizingDTO updatedFinancialSizing);
        Task<bool> DeleteFinancialSizing(int id);
        PagedList<FinancialSizingDTO> GetAllFinancialSizings(SieveModel sieveModel);
        Task<List<FinancialSizingViewResultDTO>> GetFinancialSizingView();
    }
}
