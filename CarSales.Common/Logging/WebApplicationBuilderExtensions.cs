using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace CarSales.Common.Logging;

public static class WebApplicationBuilderExtensions
{
    public static void AddSerilog(this WebApplicationBuilder builder)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("serilog.config.json")
            .Build();

        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(config)
            .CreateLogger();

        builder.Logging.ClearProviders();
        builder.Host.UseSerilog();
    }
}
