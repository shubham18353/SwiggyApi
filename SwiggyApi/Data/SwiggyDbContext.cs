using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SwiggyApi.Models.Customers;
using SwiggyApi.Models.Orders;
using SwiggyApi.Models.Products;

namespace SwiggyApi.Models.Data
{
    public class SwiggyDbContext : DbContext
    {
        public SwiggyDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(x => x.Customer_Id);

            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(x => x.Order_Id);

            });
        }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Order>? Orders { get; set; }

    }
}
