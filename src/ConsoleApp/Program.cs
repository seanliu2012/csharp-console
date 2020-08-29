using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder().BuildConfig();
            configuration.ConfigureSerilog();

            Log.Logger.Information("Application started");

            var host = CreateHost(args);

            var app = host.Services.GetService<IConsoleApplication>();
            app.Run();
        }

        static IHost CreateHost(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddTransient<IConsoleApplication, ConsoleApplication>();
                })
                .UseSerilog()
                .Build();
        }
    }
}
