using AutoMapper;
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
    public class SubBusinessLineService : ISubBusinessLineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly SieveProcessor _sieveProcessor;

        public SubBusinessLineService(IUnitOfWork unitOfWork, IMapper mapper, SieveProcessor sieveProcessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
        }

        public PagedList<SubBusinessLineDTO> GetAllSubBusinessLines(SieveModel sieveModel)
        {
            // Get all query
            IQueryable<SubBusinessLine> subBusinessLineQuery = _unitOfWork.SubBusinessLineRepository.GetAll();

            // Apply filtering to the query
            subBusinessLineQuery = _sieveProcessor.Apply(sieveModel, subBusinessLineQuery, applyPagination: false);

            // Get the total count of records
            int totalCount = subBusinessLineQuery.Count();

            // Execute the query to get paginated values
            List<SubBusinessLine> resultDB = PagedList<SubBusinessLine>.CreateSourceFromQuery(subBusinessLineQuery, sieveModel);

            // Map results to DTO
            var SubBusinessLineDB = _mapper.Map<List<SubBusinessLineDTO>>(resultDB);

            // Map the result to PagedList
            var result = PagedList<SubBusinessLineDTO>.CreateFromResults(SubBusinessLineDB, sieveModel, totalCount);

            return result;
        }

        public async Task<SubBusinessLineDTO> GetSubBusinessLine(int id)
        {
            SubBusinessLine dbRecord = await _unitOfWork.SubBusinessLineRepository.GetById(id);
            SubBusinessLineDTO result = _mapper.Map<SubBusinessLineDTO>(dbRecord);
            return result;
        }

        public async Task InsertSubBusinessLine(SubBusinessLineDTO newSubBusinessLine)
        {
            SubBusinessLine dbRecord = _mapper.Map<SubBusinessLine>(newSubBusinessLine);

            await _unitOfWork.SubBusinessLineRepository.Add(dbRecord);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();
        }

        public async Task<bool> UpdateSubBusinessLine(SubBusinessLineDTO updatedSubBusinessLineDTO)
        {
            SubBusinessLine existingRecord = await _unitOfWork.SubBusinessLineRepository.GetById(updatedSubBusinessLineDTO.Id);

            if (existingRecord == null)
            {
                throw new KeyNotFoundException();
            }

            var updatedRecord = _mapper.Map<SubBusinessLine>(updatedSubBusinessLineDTO);

            _unitOfWork.SubBusinessLineRepository.Update(existingRecord, updatedRecord);

            await _unitOfWork.SaveAdministrationSwitchChangesAsync();

            return true;
        }

        public async Task<bool> DeleteSubBusinessLine(int id)
        {
            await _unitOfWork.SubBusinessLineRepository.Delete(id);
            await _unitOfWork.SaveAdministrationSwitchChangesAsync();
            return true;
        }
    }
}
