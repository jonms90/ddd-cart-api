namespace DDDCart.Domain
{
    public class CartId(Guid aCartId) : IEquatable<CartId>
    {
        public Guid Value { get; } = aCartId;

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

            return Equals((CartId) obj);
        }

        public bool Equals(CartId? other)
        {
            return other is not null && other.Value == Value;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
