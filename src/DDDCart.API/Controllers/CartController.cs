using System.Security.Claims;
using DDDCart.API.Models;
using DDDCart.Domain.Carts;
using DDDCart.Domain.Products;
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
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;

        public CartController(
            ILogger<CartController> logger, 
            ICartRepository cartRepository, 
            IProductRepository productRepository)
        {
            _logger = logger;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        [HttpGet(Name = "GetCart")]
        public async Task<CartResponse> Get()
        {
            var userId = HttpContext.User.FindFirstValue("userid")!;
            _logger.LogDebug("Retrieving Cart");
            var cart = await _cartRepository.GetByIdAsync(new CustomerId(new Guid(userId)));
            if (cart is null)
            {
                return new CartResponse(){ CustomerId = userId, ItemCount = 0 };
            }

            return await Task.FromResult(new CartResponse()
                {CustomerId = cart.CustomerId.ToString(), ItemCount = cart.ItemCount});
        }

        [HttpPost(Name = "AddToCart")]
        [Route("items")]
        public async Task<ActionResult<CartResponse>> Post(AddProductRequest request)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestResult();
            }

            var userId = HttpContext.User.FindFirstValue("userid")!;
            var customerId = new CustomerId(new Guid(userId));
            var cart = await _cartRepository.GetByIdAsync(customerId);
            if (cart is null)
            {
                var cartId = _cartRepository.GetNextId();
                cart = new Cart(cartId, customerId);
                _cartRepository.Add(cart);
            }

            var sku = new Sku(request.Sku);
            var product = await _productRepository.GetAsync(sku);

            if (product is null)
            {
                return new NotFoundResult();
            }

            product.AddTo(cart, request.Quantity);
            await _cartRepository.SaveChangesAsync();

            return new CartResponse()
            { CustomerId = cart.CustomerId.ToString(), ItemCount = cart.ItemCount };
        }
    }
}
