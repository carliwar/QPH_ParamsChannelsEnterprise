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
    public class EnterpriseService : IEnterpriseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SieveProcessor _sieveProcessor;

        public EnterpriseService(IUnitOfWork unitOfWork, IMapper mapper, SieveProcessor sieveProcessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
        }

        public PagedList<EnterpriseDTO> GetAllEnterprises(SieveModel sieveModel)
        {
            // Get all query
            IQueryable<Enterprise> enterpriseQuery = _unitOfWork.EnterpriseRepository.GetAll();

            // Apply filtering to the query
            enterpriseQuery = _sieveProcessor.Apply(sieveModel, enterpriseQuery, applyPagination: false);

            // Get the total count of records
            int totalCount = enterpriseQuery.Count();

            // Execute the query to get paginated values
            List<Enterprise> resultDB = PagedList<Enterprise>.CreateSourceFromQuery(enterpriseQuery, sieveModel);

            // Map results to DTO
            var EnterpriseDB = _mapper.Map<List<EnterpriseDTO>>(resultDB);

            // Map the result to PagedList
            var result = PagedList<EnterpriseDTO>.CreateFromResults(EnterpriseDB, sieveModel, totalCount);

            return result;
        }

        public async Task<EnterpriseDTO> GetEnterprise(int id)
        {
            Enterprise dbRecord = await _unitOfWork.EnterpriseRepository.GetById(id);
            EnterpriseDTO result = _mapper.Map<EnterpriseDTO>(dbRecord);
            return result;
        }

        public async Task InsertEnterprise(EnterpriseDTO newEnterprise)
        {
            Enterprise dbRecord = _mapper.Map<Enterprise>(newEnterprise);

            await _unitOfWork.EnterpriseRepository.Add(dbRecord);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();
        }

        public async Task<bool> UpdateEnterprise(EnterpriseDTO updatedEnterpriseDTO)
        {
            Enterprise existingRecord = await _unitOfWork.EnterpriseRepository.GetById(updatedEnterpriseDTO.Id);

            if (existingRecord == null)
                throw new ValidationException("Registro no existe para el ID proporcionado.");

            var updatedRecord = _mapper.Map<Enterprise>(updatedEnterpriseDTO);

            _unitOfWork.EnterpriseRepository.Update(existingRecord, updatedRecord);

            await _unitOfWork.SaveAdministrationSwitchChangesAsync();

            return true;
        }

        public async Task<bool> DeleteEnterprise(int id)
        {
            await _unitOfWork.EnterpriseRepository.Delete(id);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();
            return true;
        }
    }
}
