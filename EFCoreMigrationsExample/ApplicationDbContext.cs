using EFCoreMigrationsExample.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMigrationsExample
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => oi.Id);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>().HasData(
                new Product 
                { 
                    Id = 1, Name = "Laptop", Description = "High-performance laptop", Price = 1200.00m, QuantityInStock = 10 
                },
                new Product 
                { 
                    Id = 2, Name = "Keyboard", Description = "Mechanical keyboard", Price = 75.00m, QuantityInStock = 25 
                },
                new Product 
                { 
                    Id = 3, Name = "Mouse", Description = "Wireless gaming mouse", Price = 50.00m, QuantityInStock = 30 
                },
                new Product 
                { 
                    Id = 4, Name = "Monitor", Description = "27-inch gaming monitor", Price = 300.00m, QuantityInStock =  15 
                },
                new Product 
                { 
                    Id = 5, Name = "Webcam", Description = "High-definition webcam", Price = 60.00m, QuantityInStock = 20 
                }
            );
        }
    }
}
