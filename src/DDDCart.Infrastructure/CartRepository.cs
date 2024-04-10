using DDDCart.Domain;
using Microsoft.EntityFrameworkCore;

namespace DDDCart.Infrastructure
{
    public class CartRepository : ICartRepository
    {
        private readonly CartContext _context;

        public CartRepository(CartContext context)
        {
            _context = context;
        }

        public async Task<Cart?> GetByIdAsync(CustomerId id)
        {
            return await _context.Carts.FirstOrDefaultAsync(x => x.CustomerId == id);
        }
    }
}
