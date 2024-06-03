using CarSales.Infrastructure.Persistence.EF.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using CarSales.Common.Configuration;
using Microsoft.Extensions.Configuration;
using Npgsql;
using CarSales.Infrastructure.Services;

namespace CarSales.Infrastructure.Common.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (Environment.GetEnvironmentVariable("CONTAINER") == "Docker")
        {
            connectionString = configuration.GetConnectionString("DockerConnection");
        }

        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddHostedService<BookingBackgroundService>();
    }

    public static void AddDatabaseOptions(this IServiceCollection services)
    {
        services
            .AddOptions<DatabaseOptions>()
            .BindConfiguration(DatabaseOptions.SectionName)
            .Configure<IConfiguration>((x, config) =>
            {
                var builder =
                        new NpgsqlConnectionStringBuilder(
                            config.GetConnectionString(DatabaseOptions.MainConnectionStringName));

                var host = Environment.GetEnvironmentVariable(DatabaseOptions.HostEnvVarName);
                var port = Environment.GetEnvironmentVariable(DatabaseOptions.PortEnvVarName);
                var database = Environment.GetEnvironmentVariable(DatabaseOptions.DatabaseEnvVarName);

                if (
                        !string.IsNullOrWhiteSpace(host) &&
                        int.TryParse(port, out var parsedPort) &&
                        !string.IsNullOrWhiteSpace(database))
                {
                    builder.Host = host;
                    builder.Port = parsedPort;
                    builder.Database = database;

                    var user = Environment.GetEnvironmentVariable(DatabaseOptions.UserEnvVarName);
                    var password = Environment.GetEnvironmentVariable(DatabaseOptions.PasswordEnvVarName);
                    if (!string.IsNullOrWhiteSpace(user) && !string.IsNullOrWhiteSpace(password))
                    {
                        builder.Username = user;
                        builder.Password = password;
                    }
                }

                x.ConnectionString = builder.ToString();

                builder.KeepAlive = x.KeepAlive;
                x.KeepAliveConnectionString = builder.ToString();
            })
            .ValidateDataAnnotations()
            .ValidateOnStart();
    }
}
