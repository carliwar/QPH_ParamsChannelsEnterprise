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
    public class EnterpriseController : Controller
    {
        private readonly IEnterpriseService _enterpriseService;

        public EnterpriseController(IEnterpriseService EnterpriseService)
        {
            _enterpriseService = EnterpriseService;
        }

        [HttpGet("All")]
        public IActionResult GetAllEnterprise(SieveModel sieveModel)
        {
            var Enterprises = _enterpriseService.GetAllEnterprises(sieveModel);

            var response = new ApiResponse<IEnumerable<EnterpriseDTO>>(Enterprises)
            {
                Meta = Enterprises.Metadata
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnterprise(int id)
        {
            EnterpriseDTO Enterprise = await _enterpriseService.GetEnterprise(id);
            var response = new ApiResponse<EnterpriseDTO>(Enterprise);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(EnterpriseDTO Enterprise)
        {
            var isUpdated = await _enterpriseService.UpdateEnterprise(Enterprise);
            var response = new ApiResponse<bool>(isUpdated);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(EnterpriseDTO Enterprise)
        {
            await _enterpriseService.InsertEnterprise(Enterprise);
            return Ok();
        }
    }
}
