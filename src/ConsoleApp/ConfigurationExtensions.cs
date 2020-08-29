using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;

namespace ConsoleApp
{
    public static class ConfigurationExtensions
    {
        public static IConfiguration BuildConfig(this IConfigurationBuilder builder)
        {
            return builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true, true)
                .AddEnvironmentVariables()
                .Build();
        }

        public static void ConfigureSerilog(this IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
        }
    }
}
