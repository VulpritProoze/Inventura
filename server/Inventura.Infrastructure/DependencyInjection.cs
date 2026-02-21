using Inventura.Application.Common.Interfaces;
using Inventura.Domain.Constants;
using Inventura.Infrastructure.Constants;
using Inventura.Infrastructure.Data;
using Inventura.Infrastructure.Data.Interceptors;
using Inventura.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        // Database
        var connectionString = configuration.GetConnectionString(
            EnvironmentVariableKeys.ConnectionString
        );
        Guard.Against.NullOrEmpty(
            connectionString,
            EnvironmentVariableKeys.ConnectionString,
            ExceptionMessages.MissingEnv
        );

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(
                connectionString,
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
            )
        );
        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetRequiredService<ApplicationDbContext>()
        );
        services.AddScoped<ApplicationDbContextInitializer>();

        // Identity
        services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
        services.AddAuthorizationBuilder();
        services
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddApiEndpoints();
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddAuthorization(options =>
            options.AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator))
        );

        services.AddSingleton(TimeProvider.System);

        return services;
    }
}
