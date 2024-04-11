namespace DDDCart.Domain.Carts
{
    public class CustomerId : IEquatable<CustomerId>
    {
        public Guid Value { get; }

        public CustomerId(Guid aCustomerId)
        {
            ArgumentNullException.ThrowIfNull(aCustomerId);
            Value = aCustomerId;
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

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((CustomerId)obj);
        }

        public bool Equals(CustomerId? other)
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
