using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RaffleAPI.Application.DTOs.Requests;
using RaffleAPI.Application.Interfaces.Services;

namespace RaffleAPI.Api.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class RaffleController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IRaffleService _raffleService;

        public RaffleController(IProductService productService, IRaffleService raffleService)
        {
            _productService = productService;
            _raffleService = raffleService;
        }

        [HttpPost("products")]
        [Authorize]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
        {
            var productId = await _productService.CreateProduct(request);
            return Ok(productId);
        }

        [HttpPost("assign-number")]
        [Authorize]
        public async Task<IActionResult> AssignNumber([FromBody] AssignNumberRequest request)
        {
            var assignedNumber = await _raffleService.AssignNumber(request);
            return Ok(assignedNumber);
        }
    }
}
