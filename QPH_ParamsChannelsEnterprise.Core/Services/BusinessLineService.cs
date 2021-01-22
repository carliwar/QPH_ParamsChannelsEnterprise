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
    public class BusinessLineService : IBusinessLineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SieveProcessor _sieveProcessor;

        public BusinessLineService(IUnitOfWork unitOfWork, IMapper mapper, SieveProcessor sieveProcessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
        }

        public PagedList<BusinessLineDTO> GetAllBusinessLines(SieveModel sieveModel)
        {
            // Get all query
            IQueryable<BusinessLine> businessLineQuery = _unitOfWork.BusinessLineRepository.GetAll();

            // Apply filtering to the query
            businessLineQuery = _sieveProcessor.Apply(sieveModel, businessLineQuery, applyPagination: false);

            // Get the total count of records
            int totalCount = businessLineQuery.Count();

            // Execute the query to get paginated values
            List<BusinessLine> resultDB = PagedList<BusinessLine>.CreateSourceFromQuery(businessLineQuery, sieveModel);

            // Map results to DTO
            var BusinessLineDB = _mapper.Map<List<BusinessLineDTO>>(resultDB);

            // Map the result to PagedList
            var result = PagedList<BusinessLineDTO>.CreateFromResults(BusinessLineDB, sieveModel, totalCount);

            return result;
        }

        public async Task<BusinessLineDTO> GetBusinessLine(int id)
        {
            BusinessLine dbRecord = await _unitOfWork.BusinessLineRepository.GetById(id);
            BusinessLineDTO result = _mapper.Map<BusinessLineDTO>(dbRecord);
            return result;
        }

        public async Task InsertBusinessLine(BusinessLineDTO newBusinessLine)
        {
            BusinessLine dbRecord = _mapper.Map<BusinessLine>(newBusinessLine);

            await _unitOfWork.BusinessLineRepository.Add(dbRecord);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();
        }

        public async Task<bool> UpdateBusinessLine(BusinessLineDTO updatedBusinessLineDTO)
        {
            BusinessLine existingRecord = await _unitOfWork.BusinessLineRepository.GetById(updatedBusinessLineDTO.Id);

            if (existingRecord == null)
                throw new ValidationException("Registro no existe para el ID proporcionado.");


            var updatedRecord = _mapper.Map<BusinessLine>(updatedBusinessLineDTO);

            _unitOfWork.BusinessLineRepository.Update(existingRecord, updatedRecord);

            await _unitOfWork.SaveAdministrationSwitchChangesAsync();

            return true;
        }

        public async Task<bool> DeleteBusinessLine(int id)
        {
            await _unitOfWork.BusinessLineRepository.Delete(id);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();
            return true;
        }
    }
}
