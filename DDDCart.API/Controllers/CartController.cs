using DDDCart.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DDDCart.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ILogger<CartController> _logger;

        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCart")]
        public async Task<CartResponse> Get()
        {
            return await Task.FromResult(new CartResponse());
        }
    }
}
