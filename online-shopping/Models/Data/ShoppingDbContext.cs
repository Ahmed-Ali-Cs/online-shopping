using Microsoft.EntityFrameworkCore;

namespace online_shopping.Models.Data
{
    public class ShoppingDbContext : DbContext
    {
        public ShoppingDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Description = "A high-performance laptop suitable for all your computing needs.",
                    Price = 999.99m,
                    Stock = 50
                },
                new Product
                {
                    Id = 2,
                    Name = "Smartphone",
                    Description = "A latest-generation smartphone with cutting-edge features.",
                    Price = 699.99m,
                    Stock = 150
                },
                new Product
                {
                    Id = 3,
                    Name = "Headphones",
                    Description = "Noise-cancelling headphones for an immersive audio experience.",
                    Price = 199.99m,
                    Stock = 200
                }
            );
        }
    }
}
