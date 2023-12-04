using Microsoft.EntityFrameworkCore;
using Venus.Domain.Entities;

namespace Venus.Repository;

public class VenusDbContext : DbContext
{
    public VenusDbContext(DbContextOptions<VenusDbContext> options) : base(options)
    {
    }

    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<VehicleType> VehicleTypes { get; set; }
    public DbSet<Tariff> Tariffs { get; set; }
    public DbSet<DateRelatedRule> DateRelatedRules { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TariffTypeConfiguration());
        modelBuilder.ApplyConfiguration(new VehicleConfiguration());
        modelBuilder.ApplyConfiguration(new VehicleTypeConfiguration());
        modelBuilder.ApplyConfiguration(new DateRelatedRuleConfiguration());

    }
}