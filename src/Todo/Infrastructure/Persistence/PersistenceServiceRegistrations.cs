using Application.Repositories.Todo;
using Application.Repositories.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using Persistence.Context;
using Persistence.Repositories.Todo;
using Persistence.Repositories.User;

namespace Persistence;

public static class PersistenceServiceRegistrations
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {

        services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.ConnectionString),
            ServiceLifetime.Singleton);

        services.AddScoped<IUserReadRepository, UserReadRepository>();
        services.AddScoped<IUserWriteRepository, UserWriteRepository>();

        services.AddScoped<ITodoWriteRepository, TodoWriteRepository>();
        services.AddScoped<ITodoReadRepository, TodoReadRepository>();

        return services;
    }

}
static class Configuration
{
    public static string ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();



            
            var s = Path.DirectorySeparatorChar;
            var directory = Directory.GetCurrentDirectory();
          //  Path.Combine(directory, $"{s}..{s}Presentation{s}Api");

            configurationManager.SetBasePath(directory);
            configurationManager.AddJsonFile("appsettings.json");

            return configurationManager.GetConnectionString("DefaultConnection")?? "Server=msSqlDb,1433;Database=todo;User=sa;Password=Password12;TrustServerCertificate=True;";
        }
    }
}