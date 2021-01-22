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
    public class ChannelController : Controller
    {
        private readonly IChannelService _ChannelService;

        public ChannelController(IChannelService ChannelService)
        {
            _ChannelService = ChannelService;
        }

        [HttpGet("All")]
        public IActionResult GetAllChannels(SieveModel sieveModel)
        {
            var Channels = _ChannelService.GetAllChannels(sieveModel);

            var response = new ApiResponse<IEnumerable<ChannelDTO>>(Channels)
            {
                Meta = Channels.Metadata
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChannel(int id)
        {
            ChannelDTO Channel = await _ChannelService.GetChannel(id);
            var response = new ApiResponse<ChannelDTO>(Channel);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ChannelDTO Channel)
        {
            var isUpdated = await _ChannelService.UpdateChannel(Channel);
            var response = new ApiResponse<bool>(isUpdated);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ChannelDTO Channel)
        {
            await _ChannelService.InsertChannel(Channel);
            return Ok();
        }
    }
}
