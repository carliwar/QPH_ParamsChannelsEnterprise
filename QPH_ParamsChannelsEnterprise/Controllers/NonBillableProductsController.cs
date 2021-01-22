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
    public class NonBillableProductsController : Controller
    {
        private readonly INonBillableProductsService _nonBillableProductsService;

        public NonBillableProductsController(INonBillableProductsService NonBillableProductsService)
        {
            _nonBillableProductsService = NonBillableProductsService;
        }

        [HttpGet("All")]
        public IActionResult GetAllNonBillableProducts(SieveModel sieveModel)
        {
            var NonBillableProductss = _nonBillableProductsService.GetAllNonBillableProducts(sieveModel);

            var response = new ApiResponse<IEnumerable<NonBillableProductsDTO>>(NonBillableProductss)
            {
                Meta = NonBillableProductss.Metadata
            };

            return Ok(response);
        }

        [HttpGet("ActiveNonBillableProducts")]
        public IActionResult GetAllActiveNonBillableProducts(SieveModel sieveModel)
        {
            var NonBillableProductss = _nonBillableProductsService.GetAllActiveNonBillableProducts(sieveModel);

            var response = new ApiResponse<IEnumerable<NonBillableProductsDTO>>(NonBillableProductss)
            {
                Meta = NonBillableProductss.Metadata
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNonBillableProducts(int id)
        {
            NonBillableProductsDTO NonBillableProducts = await _nonBillableProductsService.GetNonBillableProduct(id);
            var response = new ApiResponse<NonBillableProductsDTO>(NonBillableProducts);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(NonBillableProductsDTO NonBillableProducts)
        {
            var isUpdated = await _nonBillableProductsService.UpdateNonBillableProduct(NonBillableProducts);
            var response = new ApiResponse<bool>(isUpdated);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(NonBillableProductsDTO NonBillableProducts)
        {
            await _nonBillableProductsService.InsertNonBillableProduct(NonBillableProducts);
            return Ok();
        }
    }
}
