using LoggingService;
using ILogger = NLog.ILogger;

namespace CompanyApi.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options => options.AddPolicy("CorsPolicy",
            builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
    }

    public static void ConfigureIis(this IServiceCollection services)
    {
        services.Configure<IISOptions>(options => {});
    }

    public static void ConfigureLogger(this IServiceCollection services)
    {
        services.AddSingleton<Contracts.ILogger, Logger>();
    }
}