using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Venus.Domain.Entities;

namespace Venus.Repository;

public class VehicleConfiguration : BaseEntityTypeConfiguration<Vehicle>
{
    protected override void Config(EntityTypeBuilder<Vehicle> builder)
    {
        builder.Property(x => x.PlateNumber)
            .IsRequired();

        //builder.HasBaseType<VenusBaseEntity>();
        builder.HasOne(x => x.VehicleType)
            .WithMany(x => x.Vehicles);

    }
}