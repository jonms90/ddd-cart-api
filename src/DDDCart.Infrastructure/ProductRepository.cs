using DDDCart.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace DDDCart.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        private readonly CommerceContext _context;

        public ProductRepository(CommerceContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetAsync(Sku sku)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Sku == sku);
        }

        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            var p = await _context.Products.FirstOrDefaultAsync(x => x.Sku == product.Sku);
        }
    }
}
