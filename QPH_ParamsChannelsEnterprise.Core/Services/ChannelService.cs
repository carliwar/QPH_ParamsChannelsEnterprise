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
    public class ChannelService : IChannelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SieveProcessor _sieveProcessor;

        public ChannelService(IUnitOfWork unitOfWork, IMapper mapper, SieveProcessor sieveProcessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
        }

        public PagedList<ChannelDTO> GetAllChannels(SieveModel sieveModel)
        {
            // Get all query
            IQueryable<Channel> channelQuery = _unitOfWork.ChannelRepository.GetAll();

            // Apply filtering to the query
            channelQuery = _sieveProcessor.Apply(sieveModel, channelQuery, applyPagination: false);

            // Get the total count of records
            int totalCount = channelQuery.Count();

            // Execute the query to get paginated values
            List<Channel> resultDB = PagedList<Channel>.CreateSourceFromQuery(channelQuery, sieveModel);

            // Map results to DTO
            var ChannelDB = _mapper.Map<List<ChannelDTO>>(resultDB);

            // Map the result to PagedList
            var result = PagedList<ChannelDTO>.CreateFromResults(ChannelDB, sieveModel, totalCount);

            return result;
        }

        public async Task<ChannelDTO> GetChannel(long id)
        {
            Channel dbRecord = await _unitOfWork.ChannelRepository.GetById(id);
            ChannelDTO result = _mapper.Map<ChannelDTO>(dbRecord);
            return result;
        }

        public async Task InsertChannel(ChannelDTO newChannel)
        {
            CheckExistentSegment(newChannel);

            await CheckFinancialSizingValue(newChannel);

            await CheckEnterpriseValue(newChannel);

            CheckNonBillableProductsValues(newChannel);

            Channel dbRecord = _mapper.Map<Channel>(newChannel);

            await _unitOfWork.ChannelRepository.Add(dbRecord);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();

            await CreateChannelNonBillableProductsRecords(newChannel, dbRecord);
            await CreateChannelEnterpriseRecord(dbRecord, newChannel);

            await _unitOfWork.SaveAdministrationSwitchChangesAsync();
        }        

        public async Task<bool> UpdateChannel(ChannelDTO updatedChannelDTO)
        {
            Channel existingRecord = await _unitOfWork.ChannelRepository.GetById(updatedChannelDTO.Id);

            if (existingRecord == null)
                throw new ValidationException("Registro no existe para el ID proporcionado.");


            var updatedRecord = _mapper.Map<Channel>(updatedChannelDTO);

            _unitOfWork.ChannelRepository.Update(existingRecord, updatedRecord);

            await _unitOfWork.SaveAdministrationSwitchChangesAsync();

            return true;
        }

        public async Task<bool> DeleteChannel(int id)
        {
            await _unitOfWork.ChannelRepository.Delete(id);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();
            return true;
        }

        #region Private Methods

        private void CheckExistentSegment(ChannelDTO newChannel)
        {
            var segmentosExistentes = _unitOfWork.ChannelRepository.GetAll().Where(t => t.Segmento == newChannel.Segmento).ToList();

            if (segmentosExistentes != null || segmentosExistentes.Count > 0)
                throw new ValidationException("El segmento proporcionado ya existe en base de datos. Ingrese un valor nuevo.");
        }

        private async Task CheckFinancialSizingValue(ChannelDTO newChannel)
        {
            if (newChannel.FinancialSizingID.HasValue)
            {
                FinancialSizing financialSizing = await _unitOfWork.FinancialSizingRepository.GetById(newChannel.FinancialSizingID.Value);

                if (financialSizing == null)
                    throw new ValidationException("No existe registro para el Dimensionamiento Financiero proporcionado.");
            }
        }
        private void CheckNonBillableProductsValues(ChannelDTO newChannel)
        {
            var matchingNonBillableProductsItems = _unitOfWork.NonBillableProductsRepository.GetAll()
                            .Where(t => newChannel.NonBillableProducts.Contains(t.IDNonBillableProducts)).Count();

            if (matchingNonBillableProductsItems != newChannel.NonBillableProducts.Count)            
                throw new ValidationException("Uno o más Productos No Facturables proporcionados no corresponde a ningún registro.");
            
        }

        private async Task CreateChannelEnterpriseRecord(Channel dbRecord, ChannelDTO channelDTO)
        {
            var newChannelEnterprise = new ChannelEnterprise
            {
                IDChannel = dbRecord.IDChannel,
                IDEnterprise = channelDTO.EnterpriseID,
                Status = true
            };

            await _unitOfWork.ChannelEnterpriseRepository.Add(newChannelEnterprise);
        }

        private async Task CheckEnterpriseValue(ChannelDTO newChannel)
        {
            Enterprise enterprise = await _unitOfWork.EnterpriseRepository.GetById(newChannel.EnterpriseID);

            if (enterprise == null)
                throw new ValidationException("No existe registro para la empresa proporcionada.");            
        }

        private async Task CreateChannelNonBillableProductsRecords(ChannelDTO newChannel, Channel dbRecord)
        {
            var channelNonBillableProductsRecords = new List<ChannelNonBillableProducts>();

            foreach (int nonBillableID in newChannel.NonBillableProducts)
            {
                var newRecord = new ChannelNonBillableProducts
                {
                    ChannelID = dbRecord.IDChannel,
                    NonBillableProductID = nonBillableID                  
                };

                channelNonBillableProductsRecords.Add(newRecord);
            }

            await _unitOfWork.ChannelNonBillableProductsRepository.Add(channelNonBillableProductsRecords);
        }

        #endregion
    }
}
