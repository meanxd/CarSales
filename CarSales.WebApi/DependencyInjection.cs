using CleanArchitecture.Web.Infrastructure;

namespace CarSales.WebApi;

public static class DependencyInjection
{
    public static void AddWebServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.AddExceptionHandler<GlobalExceptionHandler>();
    }
}
