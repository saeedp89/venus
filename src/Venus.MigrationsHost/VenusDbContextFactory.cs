using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Venus.Repository;

namespace Venus.MigrationsHost;

public class VenusDbContextFactory : IDesignTimeDbContextFactory<VenusDbContext>
{
    public VenusDbContext CreateDbContext(string[] args)
    {
        var configuration=new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<VenusDbContext>();
        var cs = configuration.GetConnectionString("Development");
        builder.UseSqlServer(cs,b=>b.MigrationsAssembly("Venus.MigrationsHost"));
        return new VenusDbContext(builder.Options);
    }
}