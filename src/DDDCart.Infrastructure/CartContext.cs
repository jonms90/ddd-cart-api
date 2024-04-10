using DDDCart.Domain;
using Microsoft.EntityFrameworkCore;

namespace DDDCart.Infrastructure
{
    public class CartContext : DbContext
    {
        public DbSet<Cart> Carts { get; set; }

        public CartContext(DbContextOptions<CartContext> options) : base(options)
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
            });
        }
    }
}
