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
    public class CredentialsUserController : Controller
    {
        private readonly ICredentialsUserService _credentialsUserService;

        public CredentialsUserController(ICredentialsUserService CredentialsUserService)
        {
            _credentialsUserService = CredentialsUserService;
        }

        [HttpGet("All")]
        public IActionResult GetAllCredentialsUser(SieveModel sieveModel)
        {
            var CredentialsUsers = _credentialsUserService.GetAllCredentialsUsers(sieveModel);

            var response = new ApiResponse<IEnumerable<CredentialsUserDTO>>(CredentialsUsers)
            {
                Meta = CredentialsUsers.Metadata
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCredentialsUser(int id)
        {
            CredentialsUserDTO CredentialsUser = await _credentialsUserService.GetCredentialsUser(id);
            var response = new ApiResponse<CredentialsUserDTO>(CredentialsUser);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(CredentialsUserDTO CredentialsUser)
        {
            var isUpdated = await _credentialsUserService.UpdateCredentialsUser(CredentialsUser);
            var response = new ApiResponse<bool>(isUpdated);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CredentialsUserDTO CredentialsUser)
        {
            await _credentialsUserService.InsertCredentialsUser(CredentialsUser);
            return Ok();
        }
    }
}
