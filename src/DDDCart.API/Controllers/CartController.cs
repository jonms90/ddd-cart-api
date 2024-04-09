using System.Security.Claims;
using DDDCart.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDDCart.API.Controllers
{
    [Authorize]
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
            var userId = HttpContext.User.FindFirstValue("userid")!;
            _logger.LogDebug("Retrieving Cart");
            return await Task.FromResult(new CartResponse(){CustomerId = userId, ItemCount = 0});
        }
    }
}
