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
    public class FinancialDimensionService : IFinancialDimensionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SieveProcessor _sieveProcessor;

        public FinancialDimensionService(IUnitOfWork unitOfWork, IMapper mapper, SieveProcessor sieveProcessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
        }

        public PagedList<FinancialDimensionDTO> GetAllFinancialDimensions(SieveModel sieveModel)
        {
            // Get all query
            IQueryable<FinancialDimension> financialDimensionQuery = _unitOfWork.FinancialDimensionRepository.GetAll();

            // Apply filtering to the query
            financialDimensionQuery = _sieveProcessor.Apply(sieveModel, financialDimensionQuery, applyPagination: false);

            // Get the total count of records
            int totalCount = financialDimensionQuery.Count();

            // Execute the query to get paginated values
            List<FinancialDimension> resultDB = PagedList<FinancialDimension>.CreateSourceFromQuery(financialDimensionQuery, sieveModel);

            // Map results to DTO
            var FinancialDimensionDB = _mapper.Map<List<FinancialDimensionDTO>>(resultDB);

            // Map the result to PagedList
            var result = PagedList<FinancialDimensionDTO>.CreateFromResults(FinancialDimensionDB, sieveModel, totalCount);

            return result;
        }

        public async Task<FinancialDimensionDTO> GetFinancialDimension(int id)
        {
            FinancialDimension dbRecord = await _unitOfWork.FinancialDimensionRepository.GetById(id);
            FinancialDimensionDTO result = _mapper.Map<FinancialDimensionDTO>(dbRecord);
            return result;
        }

        public async Task InsertFinancialDimension(FinancialDimensionDTO newFinancialDimension)
        {
            FinancialDimension dbRecord = _mapper.Map<FinancialDimension>(newFinancialDimension);

            await _unitOfWork.FinancialDimensionRepository.Add(dbRecord);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();
        }

        public async Task<bool> UpdateFinancialDimension(FinancialDimensionDTO updatedFinancialDimensionDTO)
        {
            FinancialDimension existingRecord = await _unitOfWork.FinancialDimensionRepository.GetById(updatedFinancialDimensionDTO.Id);

            if (existingRecord == null)
                throw new ValidationException("Registro no existe para el ID proporcionado.");

            var updatedRecord = _mapper.Map<FinancialDimension>(updatedFinancialDimensionDTO);

            _unitOfWork.FinancialDimensionRepository.Update(existingRecord, updatedRecord);

            await _unitOfWork.SaveAdministrationSwitchChangesAsync();

            return true;
        }

        public async Task<bool> DeleteFinancialDimension(int id)
        {
            await _unitOfWork.FinancialDimensionRepository.Delete(id);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();
            return true;
        }
    }
}
