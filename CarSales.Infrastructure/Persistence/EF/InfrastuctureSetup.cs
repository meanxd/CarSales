using CarSales.Infrastructure.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace CarSales.Infrastructure.Persistence.EF;

public static class InfrastructureSetup
{
    public static void InitializeDatabase(IServiceProvider serviceProvider)
    {
        using var serviceScope = serviceProvider.CreateScope();

        var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

        context.Database.Migrate();

        using var conn = (NpgsqlConnection)context.Database.GetDbConnection();

        conn.Open();
        conn.ReloadTypes();

        conn.Close();
    }
}
