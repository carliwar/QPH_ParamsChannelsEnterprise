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
    public class ChannelEnterpriseService : IChannelEnterpriseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SieveProcessor _sieveProcessor;

        public ChannelEnterpriseService(IUnitOfWork unitOfWork, IMapper mapper, SieveProcessor sieveProcessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
        }

        public ISieveProcessor SieveProcessor { get; set; }

        public async Task<List<ChannelEnterpriseInfoDTO>> GetChannelEnterprisesInfo(string channel)
        {
            List<ChannelEnterpriseInfo> dbRecords = await _unitOfWork.AdministrationSwitchProceduresRepository.GetChannelEnterpriseViewResult(channel);
            var results = _mapper.Map<List<ChannelEnterpriseInfoDTO>>(dbRecords);
            return results;
        }

        public PagedListSieve<ChannelEnterpriseInfo> GetAllChannelsEnterprise(SieveModel sieveModel)
        {
            var entityFilter = _unitOfWork.AdministrationSwitchProceduresRepository.GetAllChannelEnterprise();
            var page = sieveModel?.Page ?? 1;
            var pageSize = sieveModel?.PageSize ?? 10;

            if (sieveModel != null)
            {
                // apply pagination in a later step
                entityFilter = _sieveProcessor.Apply(sieveModel, entityFilter, applyPagination: false);
            }
            var pagedPosts = PagedListSieve<ChannelEnterpriseInfo>.CreateFromQuerable(entityFilter, page, pageSize);
            return pagedPosts;
        }

        public async Task<ChannelEnterpriseInfoDTO> GetChannelEnterpriseByDocumentNumber(string documentNumber, string proveedor)
        {
            List<ChannelEnterpriseInfo> dbRecords = await _unitOfWork.AdministrationSwitchProceduresRepository.GetChannelEnterpriseViewResult(null);

            string emissionPoint = documentNumber.Substring(3, 3);

            ChannelEnterpriseInfo channel = dbRecords.FirstOrDefault(s => s.PuntoEmision == emissionPoint);

            if (channel == null)
                throw new ValidationException($"Emission Point {emissionPoint} not found. Invalid channel.");

            var result = _mapper.Map<ChannelEnterpriseInfoDTO>(channel);

            return result;
        }

        public async Task<NonBillableProductsInfoDTO> GetNonBillableProducts(string code, string channel)
        {
            GetNonBilllableProductsResult dbResult =
                await _unitOfWork.AdministrationSwitchProceduresRepository.GetNonBillableProducts(code, channel);

            if (dbResult == null)
                throw new ValidationException($"Code {code} is billable.");

            var result = _mapper.Map<NonBillableProductsInfoDTO>(dbResult);

            return result;
        }

        public async Task<bool> IsNonBillableProduct(string code, string channel)
        {
            GetNonBilllableProductsResult dbResult =
                await _unitOfWork.AdministrationSwitchProceduresRepository.GetNonBillableProducts(code, channel);

            if (dbResult == null)
                return false;

            return true;
        }

        public async Task<bool> UpdateChannelEnterprise(ChannelEnterpriseDTO channelEnterpriseDTO)
        {
            ChannelEnterprise existingRecord = await _unitOfWork.ChannelEnterpriseRepository.GetById(channelEnterpriseDTO.Id);

            if (existingRecord == null)
                throw new ValidationException("Registro no existe para el ID proporcionado.");


            var updatedRecord = _mapper.Map<ChannelEnterprise>(channelEnterpriseDTO);

            _unitOfWork.ChannelEnterpriseRepository.Update(existingRecord, updatedRecord);

            await _unitOfWork.SaveAdministrationSwitchChangesAsync();

            return true;
        }

        public async Task InsertChannelEnterprise(ChannelEnterpriseDTO newChannelEnterprise)
        {
            ChannelEnterprise dbRecord = _mapper.Map<ChannelEnterprise>(newChannelEnterprise);

            await _unitOfWork.ChannelEnterpriseRepository.Add(dbRecord);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();
        }

        public async Task DeleteChannelEnterprise(int id)
        {
            ChannelEnterprise existingRecord = await _unitOfWork.ChannelEnterpriseRepository.GetById(id);

            if (existingRecord == null)
                throw new ValidationException("Registro no existe para el ID proporcionado.");

            await _unitOfWork.ChannelEnterpriseRepository.Delete(id);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();
        }
    }
}
