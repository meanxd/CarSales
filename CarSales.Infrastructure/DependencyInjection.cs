using CarSales.Application.Common.Interfaces;
using CarSales.Infrastructure.Common.Extensions;
using CarSales.Infrastructure.Persistence.EF.Context;
using CarSales.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarSales.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.SetupEfServices();
        services.AddAppDbContext(configuration);
        services.AddDatabaseOptions();

        services.SetupBackgroundServices();

        return services;
    }

    private static IServiceCollection SetupEfServices(this IServiceCollection services)
    {
        services.AddScoped<IAppDbContext, AppDbContext>();

        return services;
    }

    private static IServiceCollection SetupBackgroundServices(this IServiceCollection services)
    {
        services.AddHostedService<BookingBackgroundService>();

        return services;
    }

}
