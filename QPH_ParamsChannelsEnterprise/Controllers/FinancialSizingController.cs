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
    public class FinancialSizingController : Controller
    {
        private readonly IFinancialSizingService _FinancialSizingService;

        public FinancialSizingController(IFinancialSizingService FinancialSizingService)
        {
            _FinancialSizingService = FinancialSizingService;
        }

        [HttpGet("All")]
        public IActionResult GetAllFinancialSizing(SieveModel sieveModel)
        {
            var FinancialSizings = _FinancialSizingService.GetAllFinancialSizings(sieveModel);

            var response = new ApiResponse<IEnumerable<FinancialSizingDTO>>(FinancialSizings)
            {
                Meta = FinancialSizings.Metadata
            };

            return Ok(response);
        }

        [HttpGet("ActiveFinancialSizing")]
        public async Task<IActionResult> GetAllActiveFinancialSizing()
        {
            var FinancialSizings = await _FinancialSizingService.GetFinancialSizingView();

            var response = new ApiResponse<List<FinancialSizingViewResultDTO>>(FinancialSizings);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFinancialSizing(int id)
        {
            FinancialSizingDTO FinancialSizing = await _FinancialSizingService.GetFinancialSizing(id);
            var response = new ApiResponse<FinancialSizingDTO>(FinancialSizing);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(FinancialSizingDTO FinancialSizing)
        {
            var isUpdated = await _FinancialSizingService.UpdateFinancialSizing(FinancialSizing);
            var response = new ApiResponse<bool>(isUpdated);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(FinancialSizingDTO FinancialSizing)
        {
            await _FinancialSizingService.InsertFinancialSizing(FinancialSizing);
            return Ok();
        }
    }
}
