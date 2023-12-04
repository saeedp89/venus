using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Venus.Domain.Entities;

namespace Venus.Repository;

public class TariffTypeConfiguration : BaseEntityTypeConfiguration<Tariff>
{
    protected override void Config(EntityTypeBuilder<Tariff> builder)
    {
        builder.Property(x => x.To)
            .IsRequired();
        builder.Property(x => x.From)
            .IsRequired();
        builder.Property(x => x.Price)
            .HasColumnType("decimal(18,4)");
    }
}