namespace DDDCart.Domain
{
    public interface ICartRepository
    {
        public Task<Cart?> GetByIdAsync(CustomerId id);
    }
}
