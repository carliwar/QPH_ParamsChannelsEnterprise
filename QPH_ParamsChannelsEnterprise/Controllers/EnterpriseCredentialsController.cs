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
    public class EnterpriseCredentialsController : Controller
    {
        private readonly IEnterpriseCredentialsService _EnterpriseCredentialsService;

        public EnterpriseCredentialsController(IEnterpriseCredentialsService EnterpriseCredentialsService)
        {
            _EnterpriseCredentialsService = EnterpriseCredentialsService;
        }

        [HttpGet("All")]
        public IActionResult GetAllEnterpriseCredentials(SieveModel sieveModel)
        {
            var EnterpriseCredentialss = _EnterpriseCredentialsService.GetAllEnterpriseCredentialss(sieveModel);

            var response = new ApiResponse<IEnumerable<EnterpriseCredentialsDTO>>(EnterpriseCredentialss)
            {
                Meta = EnterpriseCredentialss.Metadata
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnterpriseCredentials(int id)
        {
            EnterpriseCredentialsDTO EnterpriseCredentials = await _EnterpriseCredentialsService.GetEnterpriseCredentials(id);
            var response = new ApiResponse<EnterpriseCredentialsDTO>(EnterpriseCredentials);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(EnterpriseCredentialsDTO EnterpriseCredentials)
        {
            var isUpdated = await _EnterpriseCredentialsService.UpdateEnterpriseCredentials(EnterpriseCredentials);
            var response = new ApiResponse<bool>(isUpdated);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostLists([FromBody] List<EnterpriseCredentialsDTO> EnterpriseCredentialsLists)
        {
            await _EnterpriseCredentialsService.InsertEnterpriseCredentialsList(EnterpriseCredentialsLists);
            return Ok();
        }
    }
}
