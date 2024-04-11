namespace DDDCart.Domain.Products
{
    public class Sku : IEquatable<Sku>
    {
        public string Value { get; private set; }

        public Sku(string value)
        {
            Value = value;
        }

        public bool Equals(Sku? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Value == other.Value;
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
            return Equals((Sku) obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
