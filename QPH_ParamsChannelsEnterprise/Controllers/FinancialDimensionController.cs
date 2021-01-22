using Microsoft.AspNetCore.Mvc;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using QPH_ParamsChannelsEnterprise.Core.Interfaces.Services;
using QPH_ParamsChannelsEnterprise.Responses;
using Sieve.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FinancialDimensionController : Controller
    {
        private readonly IFinancialDimensionService _financialDimensionService;

        public FinancialDimensionController(IFinancialDimensionService FinancialDimensionService)
        {
            _financialDimensionService = FinancialDimensionService;
        }

        [HttpGet("All")]
        public IActionResult GetAllFinancialDimension(SieveModel sieveModel)
        {
            var FinancialDimensions = _financialDimensionService.GetAllFinancialDimensions(sieveModel);

            var response = new ApiResponse<IEnumerable<FinancialDimensionDTO>>(FinancialDimensions)
            {
                Meta = FinancialDimensions.Metadata
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFinancialDimension(int id)
        {
            FinancialDimensionDTO FinancialDimension = await _financialDimensionService.GetFinancialDimension(id);
            var response = new ApiResponse<FinancialDimensionDTO>(FinancialDimension);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(FinancialDimensionDTO FinancialDimension)
        {
            var isUpdated = await _financialDimensionService.UpdateFinancialDimension(FinancialDimension);
            var response = new ApiResponse<bool>(isUpdated);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(FinancialDimensionDTO FinancialDimension)
        {
            await _financialDimensionService.InsertFinancialDimension(FinancialDimension);
            return Ok();
        }
    }

}
