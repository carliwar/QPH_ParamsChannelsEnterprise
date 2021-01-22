using AutoMapper;
using FluentValidation;
using QPH_ParamsChannelsEnterprise.Core.CustomEntities;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;
using QPH_ParamsChannelsEnterprise.Core.Enumerators;
using QPH_ParamsChannelsEnterprise.Core.Interfaces;
using QPH_ParamsChannelsEnterprise.Core.Interfaces.Services;
using Sieve.Models;
using Sieve.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Core.Services
{
    //class EnterpriseCredentialsCredentialsService
    public class EnterpriseCredentialsService : IEnterpriseCredentialsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SieveProcessor _sieveProcessor;

        public EnterpriseCredentialsService(IUnitOfWork unitOfWork, IMapper mapper, SieveProcessor sieveProcessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
        }

        public PagedList<EnterpriseCredentialsDTO> GetAllEnterpriseCredentialss(SieveModel sieveModel)
        {
            // Get all query
            IQueryable<EnterpriseCredentials> enterpriseCredentialsQuery = _unitOfWork.EnterpriseCredentialsRepository.GetAll();

            // Apply filtering to the query
            enterpriseCredentialsQuery = _sieveProcessor.Apply(sieveModel, enterpriseCredentialsQuery, applyPagination: false);

            // Get the total count of records
            int totalCount = enterpriseCredentialsQuery.Count();

            // Execute the query to get paginated values
            List<EnterpriseCredentials> resultDB = PagedList<EnterpriseCredentials>.CreateSourceFromQuery(enterpriseCredentialsQuery, sieveModel);

            // Map results to DTO
            var EnterpriseCredentialsDB = _mapper.Map<List<EnterpriseCredentialsDTO>>(resultDB);

            // Map the result to PagedList
            var result = PagedList<EnterpriseCredentialsDTO>.CreateFromResults(EnterpriseCredentialsDB, sieveModel, totalCount);

            return result;
        }

        public async Task<EnterpriseCredentialsDTO> GetEnterpriseCredentials(int id)
        {
            EnterpriseCredentials dbRecord = await _unitOfWork.EnterpriseCredentialsRepository.GetById(id);
            EnterpriseCredentialsDTO result = _mapper.Map<EnterpriseCredentialsDTO>(dbRecord);
            return result;
        }

        public async Task InsertEnterpriseCredentials(EnterpriseCredentialsDTO newEnterpriseCredentials)
        {
            EnterpriseCredentials dbRecord = _mapper.Map<EnterpriseCredentials>(newEnterpriseCredentials);

            await _unitOfWork.EnterpriseCredentialsRepository.Add(dbRecord);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();
        }

        public async Task<bool> UpdateEnterpriseCredentials(EnterpriseCredentialsDTO updatedEnterpriseCredentialsDTO)
        {
            EnterpriseCredentials existingRecord = await _unitOfWork.EnterpriseCredentialsRepository.GetById(updatedEnterpriseCredentialsDTO.Id);

            if (existingRecord == null)
                throw new ValidationException("Registro no existe para el ID proporcionado.");

            var updatedRecord = _mapper.Map<EnterpriseCredentials>(updatedEnterpriseCredentialsDTO);

            _unitOfWork.EnterpriseCredentialsRepository.Update(existingRecord, updatedRecord);

            await _unitOfWork.SaveAdministrationSwitchChangesAsync();

            return true;
        }

        public async Task<bool> DeleteEnterpriseCredentials(int id)
        {
            await _unitOfWork.EnterpriseCredentialsRepository.Delete(id);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();
            return true;
        }

        public async Task InsertEnterpriseCredentialsList(List<EnterpriseCredentialsDTO> enterpriseCredentialsListsPostRequest)
        {
            foreach(var record in enterpriseCredentialsListsPostRequest)
            {
                if (string.IsNullOrWhiteSpace(record.Status))
                {
                    record.Status = StatusACTIVO_INACTIVOEnum.INACTIVO.ToString();
                }
            }

            var enterpriseCredentialsToCreate = _mapper.Map<List<EnterpriseCredentials>>(enterpriseCredentialsListsPostRequest);
            await _unitOfWork.EnterpriseCredentialsRepository.Add(enterpriseCredentialsToCreate);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();
        }
    }
}
