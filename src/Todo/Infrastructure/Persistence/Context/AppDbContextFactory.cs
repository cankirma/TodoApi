using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Persistence.Context;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>

{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(Configuration.ConnectionString);
        return new AppDbContext(optionsBuilder.Options);
    }
}