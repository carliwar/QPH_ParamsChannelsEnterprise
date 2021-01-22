using Microsoft.AspNetCore.Mvc;
using QPH_ParamsChannelsEnterprise.Core.CustomEntities;
using QPH_ParamsChannelsEnterprise.Core.DTOs;
using QPH_ParamsChannelsEnterprise.Core.Interfaces.Services;
using QPH_ParamsChannelsEnterprise.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QPH_ParamsChannelsEnterprise.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ManagementSequentialController : Controller
    {
        private readonly IParametersService _parametersService;
        private readonly ISwitchAtiscodeProceduresService _switchAtiscodeProceduresService;

        public ManagementSequentialController(IParametersService parametersService, ISwitchAtiscodeProceduresService switchAtiscodeProceduresService)
        {
            _parametersService = parametersService;
            _switchAtiscodeProceduresService = switchAtiscodeProceduresService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<DocumentsTypes> result = _parametersService.GetDocumentsTypesAsync();
            var apiResponse = new ApiResponse<List<DocumentsTypes>>(result);
            return Ok(apiResponse);
        }

        [HttpPost()]
        public async Task<IActionResult> Post(ManageSequential manageSequential)
        {
            AtisLogTranDTO result = await _switchAtiscodeProceduresService.LiberarSecuencial(manageSequential);
            var apiResponse = new ApiResponse<AtisLogTranDTO>(result);
            return Ok(apiResponse);
        }
    }
}
