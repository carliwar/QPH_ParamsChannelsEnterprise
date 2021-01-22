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
    public class QueryManagerController : Controller
    {
        private readonly IQueryManagerService _queryManagerService;

        public QueryManagerController(IQueryManagerService QueryManagerService)
        {
            _queryManagerService = QueryManagerService;
        }

        [HttpGet("All")]
        public IActionResult GetAllQueryManager(SieveModel sieveModel)
        {
            var QueryManagers = _queryManagerService.GetAllQueryManagers(sieveModel);

            var response = new ApiResponse<IEnumerable<QueryManagerDTO>>(QueryManagers)
            {
                Meta = QueryManagers.Metadata
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQueryManager(int id)
        {
            QueryManagerDTO QueryManager = await _queryManagerService.GetQueryManager(id);
            var response = new ApiResponse<QueryManagerDTO>(QueryManager);
            return Ok(response);
        }

        [HttpGet("GetQueryManager/{code}")]
        public async Task<IActionResult> GetByCode(string code)
        {
            QueryManagerDTO QueryManager = await _queryManagerService.GetQueryManagerByCode(code);
            var response = new ApiResponse<QueryManagerDTO>(QueryManager);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(QueryManagerDTO QueryManager)
        {
            var isUpdated = await _queryManagerService.UpdateQueryManager(QueryManager);
            var response = new ApiResponse<bool>(isUpdated);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(QueryManagerDTO QueryManager)
        {
            await _queryManagerService.InsertQueryManager(QueryManager);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _queryManagerService.DeleteQueryManager(id);
            var response = new ApiResponse<bool>(true);
            return Ok(response);
        }
    }
}
