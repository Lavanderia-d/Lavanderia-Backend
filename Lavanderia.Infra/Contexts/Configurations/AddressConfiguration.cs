using Lavanderia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lavanderia.Infra.Contexts.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(a => a.Street)
                   .HasColumnName("street")
                   .HasColumnType("varchar(255)")
                   .IsRequired();

            builder.Property(a => a.Number)
                   .HasColumnName("number")
                   .HasColumnType("varchar(6)")
                   .IsRequired();

            builder.Property(a => a.Complement)
                   .HasColumnName("complement")
                   .HasColumnType("varchar(255)");

            builder.Property(a => a.Municipality)
                   .HasColumnName("municipality")
                   .HasColumnType("varchar(100)")
                   .IsRequired();

            builder.Property(a => a.State)
                   .HasColumnName("state")
                   .HasColumnType("varchar(100)")
                   .IsRequired();

            builder.Property(a => a.PostalCode)
                   .HasColumnName("postal_code")
                   .HasColumnType("varchar(9)")
                   .IsRequired();
        }
    }
}