using AutoMapper;
using FluentValidation;
using QPH_ParamsChannelsEnterprise.Core.CustomEntities;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;
using QPH_ParamsChannelsEnterprise.Core.Interfaces;
using QPH_ParamsChannelsEnterprise.Core.Interfaces.Services;
using Sieve.Models;
using Sieve.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Core.Services
{
    public class FinancialSizingService : IFinancialSizingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SieveProcessor _sieveProcessor;

        public FinancialSizingService(IUnitOfWork unitOfWork, IMapper mapper, SieveProcessor sieveProcessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
        }

        public PagedList<FinancialSizingDTO> GetAllFinancialSizings(SieveModel sieveModel)
        {
            // Get all query
            IQueryable<FinancialSizing> financialSizingQuery = _unitOfWork.FinancialSizingRepository.GetAll();

            // Apply filtering to the query
            financialSizingQuery = _sieveProcessor.Apply(sieveModel, financialSizingQuery, applyPagination: false);

            // Get the total count of records
            int totalCount = financialSizingQuery.Count();

            // Execute the query to get paginated values
            List<FinancialSizing> resultDB = PagedList<FinancialSizing>.CreateSourceFromQuery(financialSizingQuery, sieveModel);

            // Map results to DTO
            var FinancialSizingDB = _mapper.Map<List<FinancialSizingDTO>>(resultDB);

            // Map the result to PagedList
            var result = PagedList<FinancialSizingDTO>.CreateFromResults(FinancialSizingDB, sieveModel, totalCount);

            return result;
        }

        public async Task<List<FinancialSizingViewResultDTO>> GetFinancialSizingView()
        {
            // Get all query
            List<FinancialSizingViewResults> resultDB = await _unitOfWork.AdministrationSwitchProceduresRepository.GetFinancialSizingViewResults();
       
            // Map results to DTO
            var results = _mapper.Map<List<FinancialSizingViewResultDTO>>(resultDB);

            return results;
        }

        public async Task<FinancialSizingDTO> GetFinancialSizing(int id)
        {
            FinancialSizing dbRecord = await _unitOfWork.FinancialSizingRepository.GetById(id);
            FinancialSizingDTO result = _mapper.Map<FinancialSizingDTO>(dbRecord);
            return result;
        }

        public async Task InsertFinancialSizing(FinancialSizingDTO newFinancialSizing)
        {           

            FinancialSizing dbRecord = _mapper.Map<FinancialSizing>(newFinancialSizing);

            await _unitOfWork.FinancialSizingRepository.Add(dbRecord);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();

        }

        public async Task<bool> UpdateFinancialSizing(FinancialSizingDTO updatedFinancialSizingDTO)
        {
            FinancialSizing existingRecord = await _unitOfWork.FinancialSizingRepository.GetById(updatedFinancialSizingDTO.Id);

            if (existingRecord == null)
                throw new ValidationException("Registro no existe para el ID proporcionado.");

            var updatedRecord = _mapper.Map<FinancialSizing>(updatedFinancialSizingDTO);

            _unitOfWork.FinancialSizingRepository.Update(existingRecord, updatedRecord);

            await _unitOfWork.SaveAdministrationSwitchChangesAsync();

            return true;
        }

        public async Task<bool> DeleteFinancialSizing(int id)
        {
            await _unitOfWork.FinancialSizingRepository.Delete(id);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();
            return true;
        }
       
    }

}
