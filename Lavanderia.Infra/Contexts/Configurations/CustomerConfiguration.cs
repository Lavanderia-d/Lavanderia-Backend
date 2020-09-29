using Lavanderia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lavanderia.Infra.Contexts.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(c => c.Name)
                   .HasColumnName("name")
                   .HasColumnType("varchar(255)")
                   .IsRequired();

            builder.Property(c => c.PhoneId)
                   .HasColumnName("phone_id")
                   .IsRequired();

            builder.Property(c => c.AddressId)
                   .HasColumnName("address_id")
                   .IsRequired();
        }
    }
}