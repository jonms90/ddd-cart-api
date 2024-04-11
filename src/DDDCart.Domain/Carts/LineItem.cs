using DDDCart.Domain.Products;

namespace DDDCart.Domain.Carts
{
    public class LineItem
    {
        public LineItem(Sku sku, int quantity, string displayName)
        {
            Sku = sku;
            Quantity = quantity;
            DisplayName = displayName;
        }

        public Sku Sku { get; private set;  }
        public int Quantity {get; private set; }
        public string DisplayName { get; private set; }

        protected bool Equals(LineItem other)
        {
            return Sku.Equals(other.Sku) && Quantity == other.Quantity && DisplayName == other.DisplayName;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((LineItem) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Sku, Quantity, DisplayName);
        }
    }
}
