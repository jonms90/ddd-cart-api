using DDDCart.Domain.Products;

namespace DDDCart.Domain.Carts
{
    public class Cart
    {
        public Cart(CartId cartId, CustomerId customerId)
        {
            CartId = cartId;
            CustomerId = customerId;
            _items = new List<LineItem>();
        }

        public Cart(CartId cartId, CustomerId customerId, List<LineItem> lineItems)
        {
            CartId = cartId;
            CustomerId = customerId;
            _items = lineItems;
        }

        public CartId CartId { get; private set; }
        public CustomerId CustomerId { get; private set; }
        public int ItemCount => _items.Count;

        private readonly List<LineItem> _items;
        public IReadOnlyList<LineItem> Items => _items;

        public void AddItem(Product aProduct, int quantity)
        {
            _items.Add(new LineItem(aProduct.Sku, quantity, aProduct.DisplayName));
        }
}
}
