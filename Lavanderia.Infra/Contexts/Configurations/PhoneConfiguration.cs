using Lavanderia.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lavanderia.Infra.Contexts.Configurations
{
    public class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(p => p.DDD)
                   .HasColumnName("ddd")
                   .HasColumnType("varchar(3)")
                   .IsRequired();

            builder.Property(p => p.Number)
                   .HasColumnName("number")
                   .HasColumnType("varchar(11)")
                   .IsRequired();
        }
    }
}