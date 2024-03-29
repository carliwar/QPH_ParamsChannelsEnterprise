﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QPH_ParamsChannelsEnterprise.Core.CustomEntities;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using QPH_ParamsChannelsEnterprise.Core.Entities.AdministrationSwitch;
using QPH_ParamsChannelsEnterprise.Core.Interfaces.Services;
using QPH_ParamsChannelsEnterprise.Responses;
using Sieve.Models;
using Sieve.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ChannelEnterpriseController : Controller
    {
        private readonly IChannelEnterpriseService _channelEnterpriseService;
        private readonly SieveProcessor _sieveProcessor;
        private readonly IMapper _mapper;

        public ChannelEnterpriseController(IChannelEnterpriseService channelEnterpriseService, IMapper mapper, SieveProcessor sieveProcessor)
        {
            _channelEnterpriseService = channelEnterpriseService;
            _mapper = mapper;
            _sieveProcessor = sieveProcessor;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<ChannelEnterpriseInfoDTO> results = await _channelEnterpriseService.GetChannelEnterprisesInfo(null);

            var response = new ApiResponse<IEnumerable<ChannelEnterpriseInfoDTO>>(results);

            return Ok(response);
        }

        [HttpGet("All")]
        public IActionResult GetAllChannelsEnterprise(SieveModel sieveModel)
        {
            _channelEnterpriseService.SieveProcessor = _sieveProcessor;
            PagedListSieve<ChannelEnterpriseInfo> entity = _channelEnterpriseService.GetAllChannelsEnterprise(sieveModel);
            IEnumerable<ChannelEnterpriseInfoDTO> entityDTO = _mapper.Map<IEnumerable<ChannelEnterpriseInfoDTO>>(entity);
            Metadata metadata = new Metadata
            {
                TotalCount = entity.TotalCount,
                PageSize = entity.PageSize,
                CurrentPage = entity.CurrentPage,
                TotalPages = entity.TotalPages,
                HasNextPage = entity.HasNextPage,
                HasPreviousPage = entity.HasPreviousPage,
            };
            ApiResponse<IEnumerable<ChannelEnterpriseInfoDTO>> response = new ApiResponse<IEnumerable<ChannelEnterpriseInfoDTO>>(entityDTO)
            {
                Meta = metadata
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        [HttpGet("/GetChannelByDocumentNumber")]
        public async Task<IActionResult> Get(string documentNumber, string proveedor)
        {
            ChannelEnterpriseInfoDTO result = await _channelEnterpriseService.GetChannelEnterpriseByDocumentNumber(documentNumber, proveedor);

            var response = new ApiResponse<ChannelEnterpriseInfoDTO>(result);

            return Ok(response);
        }

        [HttpGet("/GetNonBillableProducts")]
        public async Task<IActionResult> GetNonBillableProducts(string code, string channel)
        {
            NonBillableProductsInfoDTO result = await _channelEnterpriseService.GetNonBillableProducts(code, channel);

            var response = new ApiResponse<NonBillableProductsInfoDTO>(result);

            return Ok(response);
        }

        [HttpGet("/IsNonBillableProduct")]
        public async Task<IActionResult> Verify(string code, string channel)
        {
            bool result = await _channelEnterpriseService.IsNonBillableProduct(code, channel);

            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }

        [HttpGet("{channel}")]
        public async Task<IActionResult> GetChannelEnterprise(string channel)
        {
            List<ChannelEnterpriseInfoDTO> results = await _channelEnterpriseService.GetChannelEnterprisesInfo(channel);            

            var response = new ApiResponse<ChannelEnterpriseInfoDTO>(results.FirstOrDefault());

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ChannelEnterpriseDTO channelEnterprise)
        {
            await _channelEnterpriseService.InsertChannelEnterprise(channelEnterprise);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ChannelEnterpriseDTO channelEnterprise)
        {
            var isUpdated = await _channelEnterpriseService.UpdateChannelEnterprise(channelEnterprise);
            var response = new ApiResponse<bool>(isUpdated);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _channelEnterpriseService.DeleteChannelEnterprise(id);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }
    }
}
