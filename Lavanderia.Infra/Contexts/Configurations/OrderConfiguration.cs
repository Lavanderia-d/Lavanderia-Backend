using Lavanderia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lavanderia.Infra.Contexts.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(o => o.Status)
                   .HasColumnName("status")
                   .HasConversion<int>()
                   .IsRequired();

            builder.Property(o => o.CustomerId)
                   .HasColumnName("customer_id")
                   .IsRequired();
        }
    }
}