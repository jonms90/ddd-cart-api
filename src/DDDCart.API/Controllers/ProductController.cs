using DDDCart.Domain.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DDDCart.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ProductController
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpPost(Name = "Add")]
        public async Task<IActionResult> AddProduct()
        {
            var sku = new Sku("12345670001");
            var product = new Product(sku, "Firebird");
            await _repository.AddAsync(product);

            return new OkResult();
        }
    }
}
