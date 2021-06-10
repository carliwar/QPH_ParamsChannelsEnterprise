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
    public class CredentialsUserService : ICredentialsUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        private readonly SieveProcessor _sieveProcessor;

        public CredentialsUserService(IUnitOfWork unitOfWork, IMapper mapper, IPasswordService passwordService, SieveProcessor sieveProcessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordService = passwordService;
            _sieveProcessor = sieveProcessor;
        }

        public PagedList<CredentialsUserDTO> GetAllCredentialsUsers(SieveModel sieveModel)
        {
            // Get all query
            IQueryable<CredentialsUser> credentialsUserQuery = _unitOfWork.CredentialsUserRepository.GetAll();

            // Apply filtering to the query
            credentialsUserQuery = _sieveProcessor.Apply(sieveModel, credentialsUserQuery, applyPagination: false);

            // Get the total count of records
            int totalCount = credentialsUserQuery.Count();

            // Execute the query to get paginated values
            List<CredentialsUser> resultDB = PagedList<CredentialsUser>.CreateSourceFromQuery(credentialsUserQuery, sieveModel);

            // Map results to DTO
            var CredentialsUserDB = _mapper.Map<List<CredentialsUserDTO>>(resultDB);

            // Map the result to PagedList
            var result = PagedList<CredentialsUserDTO>.CreateFromResults(CredentialsUserDB, sieveModel, totalCount);

            return result;
        }

        public async Task<CredentialsUserDTO> GetCredentialsUser(int id)
        {
            CredentialsUser dbRecord = await _unitOfWork.CredentialsUserRepository.GetById(id);
            CredentialsUserDTO result = _mapper.Map<CredentialsUserDTO>(dbRecord);
            return result;
        }

        public async Task InsertCredentialsUser(CredentialsUserDTO newCredentialServer)
        {
            // Map to db record
            CredentialsUser dbRecord = _mapper.Map<CredentialsUser>(newCredentialServer);

            // Encrypt password
            //dbRecord.Password = _passwordService.Hash(dbRecord.Password);

            await _unitOfWork.CredentialsUserRepository.Add(dbRecord);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();

        }

        public async Task<bool> UpdateCredentialsUser(CredentialsUserDTO updatedCredentialsUserDTO)
        {
            CredentialsUser existingRecord = await _unitOfWork.CredentialsUserRepository.GetById(updatedCredentialsUserDTO.Id);

            if (existingRecord == null)
                throw new ValidationException("Registro no existe para el ID proporcionado.");

            var updatedRecord = _mapper.Map<CredentialsUser>(updatedCredentialsUserDTO);

            _unitOfWork.CredentialsUserRepository.Update(existingRecord, updatedRecord);

            await _unitOfWork.SaveAdministrationSwitchChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCredentialsUser(int id)
        {
            await _unitOfWork.CredentialsUserRepository.Delete(id);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();
            return true;
        }
    }
}
