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
    public class ParametersController : Controller
    {
        private readonly IParametersService _parametersService;

        public ParametersController(IParametersService parametersService)
        {
            _parametersService = parametersService;
        }

        [HttpGet("All")]
        public IActionResult GetAllParameters(SieveModel sieveModel)
        {
            var Parameterss = _parametersService.GetAllParameters(sieveModel);

            var response = new ApiResponse<IEnumerable<ParametersDTO>>(Parameterss)
            {
                Meta = Parameterss.Metadata
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetParameters(int id)
        {
            ParametersDTO Parameters = await _parametersService.GetParameter(id);
            var response = new ApiResponse<ParametersDTO>(Parameters);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ParametersDTO Parameters)
        {
            var isUpdated = await _parametersService.UpdateParameter(Parameters);
            var response = new ApiResponse<bool>(isUpdated);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ParametersDTO Parameters)
        {
            await _parametersService.InsertParameter(Parameters);
            return Ok();
        }
    }
}
