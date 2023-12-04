using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Venus.Domain.Entities;

namespace Venus.Repository;

public class VehicleTypeConfiguration : BaseEntityTypeConfiguration<VehicleType>
{
    protected override void Config(EntityTypeBuilder<VehicleType> builder)
    {
        builder.Property(x => x.IsActive)
            .IsRequired();
        //builder.HasBaseType<VenusBaseEntity>();

        builder.Property(x => x.FreeOfCharge)
            .IsRequired();

        builder.HasMany(x => x.Vehicles).WithOne(x => x.VehicleType);
    }
}