using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Venus.Domain.Entities;

namespace Venus.Repository;

public abstract class BaseEntityTypeConfiguration<TVenusEntity> : IEntityTypeConfiguration<TVenusEntity>
    where TVenusEntity : VenusBaseEntity
{
    public void Configure(EntityTypeBuilder<TVenusEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.CreatedOn)
            .ValueGeneratedOnAdd()
            .HasDefaultValueSql("GETUTCDATE()");
        Config(builder);
    }

    protected abstract void Config(EntityTypeBuilder<TVenusEntity> builder);
}