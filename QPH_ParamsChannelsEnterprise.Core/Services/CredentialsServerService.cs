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
using QPH.Encriptacion;
using QPH.Encriptacion.Core.Interfaces;

namespace QPH_ParamsChannelsEnterprise.Core.Services
{
    public class CredentialsServerService : ICredentialsServerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        private readonly SieveProcessor _sieveProcessor;
        private readonly IEncriptador _qphEncriptador;

        public CredentialsServerService(IUnitOfWork unitOfWork, IMapper mapper, IPasswordService passwordService, IEncriptador qphEncriptador, SieveProcessor sieveProcessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _passwordService = passwordService;
            _qphEncriptador = qphEncriptador;
            _sieveProcessor = sieveProcessor;
        }

        public PagedList<CredentialsServerDTO> GetAllCredentialsServers(SieveModel sieveModel)
        {
            // Get all query
            IQueryable<CredentialsServer> credentialsServerQuery = _unitOfWork.CredentialsServerRepository.GetAll();            

            // Apply filtering to the query
            credentialsServerQuery = _sieveProcessor.Apply(sieveModel, credentialsServerQuery, applyPagination: false);

            // Get the total count of records
            int totalCount = credentialsServerQuery.Count();
                        
            // Execute the query to get paginated values
            List<CredentialsServer> resultDB = PagedList<CredentialsServer>.CreateSourceFromQuery(credentialsServerQuery, sieveModel);

            // Map results to DTO
            var credentialsServerDB = _mapper.Map<List<CredentialsServerDTO>>(resultDB);

            // Encrypt user & password
            foreach(var credential in credentialsServerDB)
            {
                credential.Password = _qphEncriptador.Encriptar(credential.Password);
            }

            // Map the result to PagedList
            var result = PagedList<CredentialsServerDTO>.CreateFromResults(credentialsServerDB, sieveModel, totalCount);

            return result;
        }        

        public async Task<CredentialsServerDTO> GetCredentialsServer(int id)
        {
            CredentialsServer dbRecord = await _unitOfWork.CredentialsServerRepository.GetById(id);
            CredentialsServerDTO result = _mapper.Map<CredentialsServerDTO>(dbRecord);
            result.Password = _qphEncriptador.Encriptar(result.Password);
            return result;
        }

        public async Task InsertCredentialsServer(CredentialsServerDTO newCredentialServer)
        {
            // Map to db record
            CredentialsServer dbRecord = _mapper.Map<CredentialsServer>(newCredentialServer);

            // Decrypt password
            dbRecord.Password = _qphEncriptador.Desencriptar(dbRecord.Password);
            dbRecord.Password = _passwordService.Hash(dbRecord.Password);

            await _unitOfWork.CredentialsServerRepository.Add(dbRecord);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();

        }

        public async Task<bool> UpdateCredentialsServer(CredentialsServerDTO updatedCredentialsServerDTO)
        {
            CredentialsServer existingRecord = await _unitOfWork.CredentialsServerRepository.GetById(updatedCredentialsServerDTO.Id);

            if (existingRecord == null)
                throw new ValidationException("Registro no existe para el ID proporcionado.");            

            var updatedRecord = _mapper.Map<CredentialsServer>(updatedCredentialsServerDTO);

            // Decrypt password to save
            updatedRecord.Password = _qphEncriptador.Desencriptar(updatedRecord.Password);
            updatedRecord.Password = _passwordService.Hash(updatedRecord.Password);

            _unitOfWork.CredentialsServerRepository.Update(existingRecord, updatedRecord);

            await _unitOfWork.SaveAdministrationSwitchChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCredentialsServer(int id)
        {
            await _unitOfWork.CredentialsServerRepository.Delete(id);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();
            return true;
        }
    }
}
