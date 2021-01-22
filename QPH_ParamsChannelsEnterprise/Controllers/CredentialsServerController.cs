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
    public class CredentialsServerController : Controller
    {
        private readonly ICredentialsServerService _credentialsServerService;

        public CredentialsServerController(ICredentialsServerService credentialsServerService)
        {
            _credentialsServerService = credentialsServerService;
        }

        [HttpGet("All")]
        public IActionResult GetAllCredentialServer(SieveModel sieveModel)
        {
            var credentialsServers = _credentialsServerService.GetAllCredentialsServers(sieveModel);

            var response = new ApiResponse<IEnumerable<CredentialsServerDTO>>(credentialsServers)
            {
                Meta = credentialsServers.Metadata
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCredentialServer(int id)
        {
            CredentialsServerDTO credentialServer = await _credentialsServerService.GetCredentialsServer(id);
            var response = new ApiResponse<CredentialsServerDTO>(credentialServer);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(CredentialsServerDTO credentialsServer)
        {
            var isUpdated = await _credentialsServerService.UpdateCredentialsServer(credentialsServer);
            var response = new ApiResponse<bool>(isUpdated);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CredentialsServerDTO credentialsServer)
        {
            await _credentialsServerService.InsertCredentialsServer(credentialsServer);
            return Ok();
        }
    }
}
