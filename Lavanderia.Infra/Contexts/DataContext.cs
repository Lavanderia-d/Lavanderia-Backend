using Lavanderia.Domain.Models;
using Lavanderia.Infra.Contexts.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Lavanderia.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>().ToTable("customer");
            builder.Entity<Phone>().ToTable("phone");
            builder.Entity<Address>().ToTable("address");
            builder.Entity<Order>().ToTable("order");
            builder.Entity<OrderItem>().ToTable("order_item");

            builder.Entity<Customer>()
                   .HasOne<Phone>(c => c.Phone)
                   .WithOne(p => p.Customer)
                   .HasForeignKey<Customer>(c => c.PhoneId);

            builder.Entity<Customer>()
                   .HasOne<Address>(c => c.Address)
                   .WithOne(a => a.Customer)
                   .HasForeignKey<Customer>(c => c.AddressId);

            builder.Entity<Customer>()
                   .HasMany<Order>(c => c.Orders)
                   .WithOne(o => o.Customer)
                   .HasForeignKey(o => o.CustomerId);

            builder.Entity<Order>()
                   .HasMany<OrderItem>(o => o.Items)
                   .WithOne(i => i.Order)
                   .HasForeignKey(i => i.OrderId);

            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new OrderConfiguration());
            builder.ApplyConfiguration(new OrderItemConfiguration());
            builder.ApplyConfiguration(new PhoneConfiguration());
            builder.ApplyConfiguration(new AddressConfiguration());
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> Items { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}