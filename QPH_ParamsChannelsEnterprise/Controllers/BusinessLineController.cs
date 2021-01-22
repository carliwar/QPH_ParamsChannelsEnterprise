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
    public class BusinessLineController : Controller
    {
        private readonly IBusinessLineService _businessLineService;

        public BusinessLineController(IBusinessLineService BusinessLineService)
        {
            _businessLineService = BusinessLineService;
        }

        [HttpGet("All")]
        public IActionResult GetAllBusinessLine(SieveModel sieveModel)
        {
            var BusinessLines = _businessLineService.GetAllBusinessLines(sieveModel);

            var response = new ApiResponse<IEnumerable<BusinessLineDTO>>(BusinessLines)
            {
                Meta = BusinessLines.Metadata
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusinessLine(int id)
        {
            BusinessLineDTO BusinessLine = await _businessLineService.GetBusinessLine(id);
            var response = new ApiResponse<BusinessLineDTO>(BusinessLine);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(BusinessLineDTO BusinessLine)
        {
            var isUpdated = await _businessLineService.UpdateBusinessLine(BusinessLine);
            var response = new ApiResponse<bool>(isUpdated);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(BusinessLineDTO BusinessLine)
        {
            await _businessLineService.InsertBusinessLine(BusinessLine);
            return Ok();
        }
    }
}
