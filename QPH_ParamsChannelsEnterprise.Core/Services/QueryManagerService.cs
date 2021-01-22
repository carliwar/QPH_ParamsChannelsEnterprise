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
    public class QueryManagerService : IQueryManagerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SieveProcessor _sieveProcessor;

        public QueryManagerService(IUnitOfWork unitOfWork, IMapper mapper, SieveProcessor sieveProcessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
        }

        public PagedList<QueryManagerDTO> GetAllQueryManagers(SieveModel sieveModel)
        {
            // Get all query
            IQueryable<QueryManager> queryManagerQuery = _unitOfWork.QueryManagerRepository.GetAll();

            // Apply filtering to the query
            queryManagerQuery = _sieveProcessor.Apply(sieveModel, queryManagerQuery, applyPagination: false);

            // Get the total count of records
            int totalCount = queryManagerQuery.Count();

            // Execute the query to get paginated values
            List<QueryManager> resultDB = PagedList<QueryManager>.CreateSourceFromQuery(queryManagerQuery, sieveModel);

            // Map results to DTO
            var QueryManagerDB = _mapper.Map<List<QueryManagerDTO>>(resultDB);

            // Map the result to PagedList
            var result = PagedList<QueryManagerDTO>.CreateFromResults(QueryManagerDB, sieveModel, totalCount);

            return result;
        }

        public async Task<QueryManagerDTO> GetQueryManager(int id)
        {
            QueryManager dbRecord = await _unitOfWork.QueryManagerRepository.GetById(id);
            QueryManagerDTO result = _mapper.Map<QueryManagerDTO>(dbRecord);
            return result;
        }

        public async Task InsertQueryManager(QueryManagerDTO newQueryManager)
        {            
            await CheckExistingCode(newQueryManager);

            QueryManager dbRecord = _mapper.Map<QueryManager>(newQueryManager);

            await _unitOfWork.QueryManagerRepository.Add(dbRecord);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();

        }

        public async Task<bool> UpdateQueryManager(QueryManagerDTO updatedQueryManagerDTO)
        {
            QueryManager existingRecord = await _unitOfWork.QueryManagerRepository.GetById(updatedQueryManagerDTO.Id);

            if (existingRecord == null)
            {
                throw new KeyNotFoundException();
            }

            await CheckExistingCode(updatedQueryManagerDTO, existingRecord.IDQueryManager);

            var updatedRecord = _mapper.Map<QueryManager>(updatedQueryManagerDTO);

            _unitOfWork.QueryManagerRepository.Update(existingRecord, updatedRecord);

            await _unitOfWork.SaveAdministrationSwitchChangesAsync();

            return true;
        }

        public async Task<bool> DeleteQueryManager(int id)
        {
            await _unitOfWork.QueryManagerRepository.Delete(id);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();
            return true;
        }

        public async Task<QueryManagerDTO> GetQueryManagerByCode(string code)
        {
            QueryManager dbRecord = await _unitOfWork.AdministrationSwitchProceduresRepository.GetQueryManagerResult(code);
            QueryManagerDTO result = _mapper.Map<QueryManagerDTO>(dbRecord);
            return result;
        }

        #region Private Methods
        private async Task CheckExistingCode(QueryManagerDTO newQueryManager, int oldID = 0)
        {
            QueryManager existingRecord = await _unitOfWork.QueryManagerRepository.GetByCode(newQueryManager.Code, oldID);

            if (existingRecord != null)
                throw new ValidationException("El código ingresado ya existe. Ingrese un código nuevo.");
        }
       
        #endregion
    }
}
