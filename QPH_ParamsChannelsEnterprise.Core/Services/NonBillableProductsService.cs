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
    public class NonBillableProductsService : INonBillableProductsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SieveProcessor _sieveProcessor;

        public NonBillableProductsService(IUnitOfWork unitOfWork, IMapper mapper, SieveProcessor sieveProcessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
        }

        public PagedList<NonBillableProductsDTO> GetAllNonBillableProducts(SieveModel sieveModel)
        {
            // Get all query
            IQueryable<NonBillableProducts> nonBillableProductsQuery = _unitOfWork.NonBillableProductsRepository.GetAll();

            // Apply filtering to the query
            nonBillableProductsQuery = _sieveProcessor.Apply(sieveModel, nonBillableProductsQuery, applyPagination: false);

            // Get the total count of records
            int totalCount = nonBillableProductsQuery.Count();

            // Execute the query to get paginated values
            List<NonBillableProducts> resultDB = PagedList<NonBillableProducts>.CreateSourceFromQuery(nonBillableProductsQuery, sieveModel);

            // Map results to DTO
            var NonBillableProductsDB = _mapper.Map<List<NonBillableProductsDTO>>(resultDB);

            // Map the result to PagedList
            var result = PagedList<NonBillableProductsDTO>.CreateFromResults(NonBillableProductsDB, sieveModel, totalCount);

            return result;
        }

        public PagedList<NonBillableProductsDTO> GetAllActiveNonBillableProducts(SieveModel sieveModel)
        {
            // Get all query
            IQueryable<NonBillableProducts> serviceCredentialsQuery = _unitOfWork.NonBillableProductsRepository.GetAll().Where(t => t.Status);

            // Apply filtering to the query
            serviceCredentialsQuery = _sieveProcessor.Apply(sieveModel, serviceCredentialsQuery, applyPagination: false);

            // Get the total count of records
            int totalCount = serviceCredentialsQuery.Count();

            // Execute the query to get paginated values
            List<NonBillableProducts> resultDB = PagedList<NonBillableProducts>.CreateSourceFromQuery(serviceCredentialsQuery, sieveModel);

            // Map results to DTO
            var NonBillableProductsDB = _mapper.Map<List<NonBillableProductsDTO>>(resultDB);

            // Map the result to PagedList
            var result = PagedList<NonBillableProductsDTO>.CreateFromResults(NonBillableProductsDB, sieveModel, totalCount);

            return result;
        }

        public async Task<NonBillableProductsDTO> GetNonBillableProduct(int id)
        {
            NonBillableProducts dbRecord = await _unitOfWork.NonBillableProductsRepository.GetById(id);
            NonBillableProductsDTO result = _mapper.Map<NonBillableProductsDTO>(dbRecord);
            return result;
        }

        public async Task InsertNonBillableProduct(NonBillableProductsDTO newNonBillableProduct)
        {
            await CheckExistingCode(newNonBillableProduct);

            NonBillableProducts dbRecord = _mapper.Map<NonBillableProducts>(newNonBillableProduct);

            await _unitOfWork.NonBillableProductsRepository.Add(dbRecord);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();

        }        

        public async Task<bool> UpdateNonBillableProduct(NonBillableProductsDTO updatedNonBillableProductDTO)
        {
            NonBillableProducts existingRecord = await _unitOfWork.NonBillableProductsRepository.GetById(updatedNonBillableProductDTO.Id);

            if (existingRecord == null)
                throw new ValidationException("Registro no existe para el ID proporcionado.");

            await CheckExistingCode(updatedNonBillableProductDTO, existingRecord.IDNonBillableProducts);

            var updatedRecord = _mapper.Map<NonBillableProducts>(updatedNonBillableProductDTO);

            _unitOfWork.NonBillableProductsRepository.Update(existingRecord, updatedRecord);

            await _unitOfWork.SaveAdministrationSwitchChangesAsync();

            return true;
        }

        public async Task<bool> DeleteNonBillableProduct(int id)
        {
            await _unitOfWork.NonBillableProductsRepository.Delete(id);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();
            return true;
        }

        public async Task<NonBillableProductsInfoDTO> GetNonBillableProduct(string code, string channel)
        {
            GetNonBilllableProductsResult dbResult =
                await _unitOfWork.AdministrationSwitchProceduresRepository.GetNonBillableProducts(code, channel);

            if (dbResult == null)
                throw new ValidationException($"Code {code} is billable");

            NonBillableProductsInfoDTO result = _mapper.Map<NonBillableProductsInfoDTO>(dbResult);

            return result;
        }

        #region Private Methods
        private async Task CheckExistingCode(NonBillableProductsDTO newNonBillableProduct, int oldID = 0)
        {            
            NonBillableProducts existingRecord = await _unitOfWork.NonBillableProductsRepository.GetByCode(newNonBillableProduct.Code, oldID);

            if (existingRecord != null)
                throw new ValidationException("El código ingresado ya existe. Ingrese un código nuevo.");
        }

        


        #endregion
    }

}
