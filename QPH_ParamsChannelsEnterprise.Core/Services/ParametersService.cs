using AutoMapper;
using FluentValidation;
using QPH_ParamsChannelsEnterprise.Core.CustomEntities;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using QPH_ParamsChannelsEnterprise.Core.Entities.SwitchAtiscode;
using QPH_ParamsChannelsEnterprise.Core.Interfaces;
using QPH_ParamsChannelsEnterprise.Core.Interfaces.Services;
using Sieve.Models;
using Sieve.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Core.Services
{
    public class ParametersService : IParametersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SieveProcessor _sieveProcessor;

        public ParametersService(IUnitOfWork unitOfWork, IMapper mapper, SieveProcessor sieveProcessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
        }

        public PagedList<ParametersDTO> GetAllParameters(SieveModel sieveModel)
        {
            // Get all query
            IQueryable<Parameters> ParametersQuery = _unitOfWork.ParametersRepository.GetAll();

            // Apply filtering to the query
            ParametersQuery = _sieveProcessor.Apply(sieveModel, ParametersQuery, applyPagination: false);

            // Get the total count of records
            int totalCount = ParametersQuery.Count();

            // Execute the query to get paginated values
            List<Parameters> resultDB = PagedList<Parameters>.CreateSourceFromQuery(ParametersQuery, sieveModel);

            // Map results to DTO
            var ParametersDB = _mapper.Map<List<ParametersDTO>>(resultDB);

            // Map the result to PagedList
            var result = PagedList<ParametersDTO>.CreateFromResults(ParametersDB, sieveModel, totalCount);

            return result;
        }

        public async Task<ParametersDTO> GetParameter(int id)
        {
            Parameters dbRecord = await _unitOfWork.ParametersRepository.GetById(id);
            ParametersDTO result = _mapper.Map<ParametersDTO>(dbRecord);
            return result;
        }

        public async Task InsertParameter(ParametersDTO newParameters)
        {
            Parameters dbRecord = _mapper.Map<Parameters>(newParameters);

            await _unitOfWork.ParametersRepository.Add(dbRecord);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();
        }

        public async Task<bool> UpdateParameter(ParametersDTO updatedParametersDTO)
        {
            Parameters existingRecord = await _unitOfWork.ParametersRepository.GetById(updatedParametersDTO.Id);

            if (existingRecord == null)
                throw new ValidationException("Registro no existe para el ID proporcionado.");

            var updatedRecord = _mapper.Map<Parameters>(updatedParametersDTO);

            _unitOfWork.ParametersRepository.Update(existingRecord, updatedRecord);

            await _unitOfWork.SaveAdministrationSwitchChangesAsync();

            return true;
        }

        public async Task<bool> DeleteParameter(int id)
        {
            await _unitOfWork.ParametersRepository.Delete(id);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();
            return true;
        }

        public List<DocumentsTypes> GetDocumentsTypesAsync()
        {
            var typeDocuments = new List<string>();
            Parameters parameter = _unitOfWork.ParametersRepository.GetAll().SingleOrDefault(t => t.Code == "TYPESDOCUMENTS");

            if (parameter == null)
                throw new ValidationException("No existen registros para con el código 'TYPEDOCUMENTS'.");

            typeDocuments = parameter.Value.Split(',').ToList();

            List<DocumentsTypes> result = typeDocuments.Select(
                (s, i) => new DocumentsTypes
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = s
                }).ToList();

            return result;
        }        
    }

}
