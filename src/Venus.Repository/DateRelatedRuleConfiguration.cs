using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Venus.Domain.Entities;

namespace Venus.Repository;

public class DateRelatedRuleConfiguration : BaseEntityTypeConfiguration<DateRelatedRule>
{
    protected override void Config(EntityTypeBuilder<DateRelatedRule> builder)
    {
        builder.Property(x => x.IsActive)
            .HasDefaultValue(true);
        builder.Property(x=>x.IsFreeOfCharge)
            .HasDefaultValue(true);
        
    }
}