using System.Text.Json;
using DDDCart.Domain.Carts;
using DDDCart.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DDDCart.Infrastructure
{
    public class CommerceContext : DbContext
    {
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Product> Products { get; set; }

        public CommerceContext(DbContextOptions<CommerceContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(cart =>
            {
                cart.ToTable("carts", schema: "commerce");
                cart.HasKey(c => c.CartId);
                cart.Property(c => c.CartId)
                    .HasConversion(c => c.Value, c => new CartId(c));
                cart.Property(c => c.CustomerId)
                    .HasConversion(c => c.Value, c => new CustomerId(c));
                cart.Ignore(c => c.ItemCount);
                cart.Property(c => c.Items).
                    HasField("_items").
                    UsePropertyAccessMode(PropertyAccessMode.FieldDuringConstruction).
                    HasConversion(v => JsonSerializer.Serialize(v, (JsonSerializerOptions) null),
                        v => JsonSerializer.Deserialize<List<LineItem>>(v, (JsonSerializerOptions)null),
                    new ValueComparer<IReadOnlyList<LineItem>>((c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => c.ToList()));
            });

            modelBuilder.Entity<Product>(product =>
            {
                product.ToTable("products", schema: "commerce");
                product.HasKey(p => p.Sku);
                product.Property(p => p.Sku)
                    .HasConversion(p => p.Value, p => new Sku(p));
            });

        }
    }
}
