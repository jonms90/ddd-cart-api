namespace DDDCart.Domain.Carts
{
    public interface ICartRepository
    {
        public Task<Cart?> GetByIdAsync(CustomerId anCustomerId);
        public CartId GetNextId();
        public void Add(Cart aCart);
        public Task SaveChangesAsync();
    }
}
