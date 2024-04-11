namespace DDDCart.Domain.Products
{
    public interface IProductRepository
    {
        public Task<Product?> GetAsync(Sku sku);
        public Task AddAsync(Product product);
    }
}
