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
    public class SubBusinessLineController : Controller
    {
        private readonly ISubBusinessLineService _subBusinessLineService;

        public SubBusinessLineController(ISubBusinessLineService SubBusinessLineService)
        {
            _subBusinessLineService = SubBusinessLineService;
        }

        [HttpGet("All")]
        public IActionResult GetAllSubBusinessLine(SieveModel sieveModel)
        {
            var SubBusinessLines = _subBusinessLineService.GetAllSubBusinessLines(sieveModel);

            var response = new ApiResponse<IEnumerable<SubBusinessLineDTO>>(SubBusinessLines)
            {
                Meta = SubBusinessLines.Metadata
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubBusinessLine(int id)
        {
            SubBusinessLineDTO SubBusinessLine = await _subBusinessLineService.GetSubBusinessLine(id);
            var response = new ApiResponse<SubBusinessLineDTO>(SubBusinessLine);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(SubBusinessLineDTO SubBusinessLine)
        {
            var isUpdated = await _subBusinessLineService.UpdateSubBusinessLine(SubBusinessLine);
            var response = new ApiResponse<bool>(isUpdated);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SubBusinessLineDTO SubBusinessLine)
        {
            await _subBusinessLineService.InsertSubBusinessLine(SubBusinessLine);
            return Ok();
        }
    }
}
