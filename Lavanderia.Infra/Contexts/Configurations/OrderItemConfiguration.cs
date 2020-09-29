using Lavanderia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lavanderia.Infra.Contexts.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(i => i.Type)
                   .HasColumnName("type")
                   .HasConversion<int>()
                   .IsRequired();

            builder.Property(i => i.Color)
                   .HasColumnName("color")
                   .HasColumnType("varchar(30)")
                   .IsRequired();

            builder.Property(i => i.Value)
                   .HasColumnName("value")
                   .IsRequired();

            builder.Property(i => i.OrderId)
                   .HasColumnName("order_id")
                   .IsRequired();
        }
    }
}