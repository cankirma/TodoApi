using System.Text;
using Infrastructure.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure;

public static class InfrastructureServiceRegistrations
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddTransient<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddAuth();
        services.AddHttpLogging(httpLogging =>
        {
            httpLogging.LoggingFields = HttpLoggingFields.All;
            httpLogging.MediaTypeOptions.
                AddText("application/javascript");
            httpLogging.RequestBodyLogLimit = 4096;
            httpLogging.ResponseBodyLogLimit = 4096;
        });
        services.AddLogging(builder =>
        {
            builder.AddConsole(opt =>
            {
                opt.IncludeScopes = true;
                opt.TimestampFormat = "[HH:mm:ss] ";
                opt.DisableColors = false;
                opt.LogToStandardErrorThreshold = LogLevel.Information;
                opt.FormatterName = "ConsoleLogger";
            });
        });
        return services;
    }
    public static IServiceCollection AddAuth(this IServiceCollection services)
    {
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                
                ValidateIssuerSigningKey = true,
                ValidIssuer = "ottoo",
                ValidAudience = "ottoo",
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("IyQ8nmoZ4Q7Fnfn9V4FqaSEQdEq7TJVWX1zJohOIN4UHhqoacx"))
            });

        return services;
    }
}