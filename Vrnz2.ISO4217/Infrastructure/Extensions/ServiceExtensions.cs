using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using Vrnz2.ISO4217.UseCases.ReadingIso4217Source;

namespace Vrnz2.ISO4217.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddISO4217(this IServiceCollection service, double executionInterval)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console(Serilog.Events.LogEventLevel.Verbose, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}", theme: AnsiConsoleTheme.Code)
                .CreateLogger();

            UpdateIso4217DataSource.Handler.Instance.UpdateDataSource(Log.Logger);
            UpdateIso4217DataSource.Handler.Instance.Handle(executionInterval);

            return service;
        }

        public static IServiceCollection AddISO4217(this IServiceCollection service) 
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console(Serilog.Events.LogEventLevel.Verbose, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}", theme: AnsiConsoleTheme.Code)
                .CreateLogger();

            UpdateIso4217DataSource.Handler.Instance.Handle(Log.Logger);
            UpdateIso4217DataSource.Handler.Instance.Handle();

            return service;
        }
    }
}
