using DDDCart.Domain.Carts;

namespace DDDCart.Domain.Products
{
    public class Product
    {
        public Product(Sku sku, string displayName)
        {
            Sku = sku;
            DisplayName = displayName;
        }

        public Sku Sku { get; private set; }
        public string DisplayName { get; private set; }

        public void AddTo(Cart cart, int quantity)
        {
            cart.AddItem(this, quantity);
        }
    }
}
