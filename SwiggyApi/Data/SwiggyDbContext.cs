using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SwiggyApi.Models.Customers;
using SwiggyApi.Models.Orders;
using SwiggyApi.Models.Products;
using SwiggyApi.Models.RegisterAndLogin;

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
            modelBuilder.Entity<Register>(entity =>
            {
                entity.HasKey(x => new { x.Username, x.Password });

            });
            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(x => x.LoginId);

            });
        }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<Register> registers { get; set; }
        public DbSet<Login> Logins { get; set; }

    }
}
