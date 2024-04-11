using DDDCart.Domain.Carts;
using Microsoft.EntityFrameworkCore;

namespace DDDCart.Infrastructure
{
    public class CartRepository : ICartRepository
    {
        private readonly CommerceContext _context;

        public CartRepository(CommerceContext context)
        {
            _context = context;
        }

        public async Task<Cart?> GetByIdAsync(CustomerId id)
        {
            return await _context.Carts.FirstOrDefaultAsync(x => x.CustomerId == id);
        }

        public CartId GetNextId()
        {
            return new CartId(Guid.NewGuid());
        }

        public void Add(Cart aCart)
        {
            _context.Carts.Add(aCart);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
