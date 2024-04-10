using System.Security.Claims;
using DDDCart.API.Models;
using DDDCart.Domain;
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
        private readonly ICartRepository _repository;

        public CartController(ILogger<CartController> logger, ICartRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet(Name = "GetCart")]
        public async Task<CartResponse> Get()
        {
            var userId = HttpContext.User.FindFirstValue("userid")!;
            _logger.LogDebug("Retrieving Cart");
            var cart = await _repository.GetByIdAsync(new CustomerId(new Guid(userId)));
            if (cart is null)
            {
                return new CartResponse(){ CustomerId = userId, ItemCount = 0 };
            }

            return await Task.FromResult(new CartResponse()
                {CustomerId = cart.CustomerId.ToString(), ItemCount = 0});
        }
    }
}
