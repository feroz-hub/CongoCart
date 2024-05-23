using BuildingBlocks.Exceptions.Handler;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Catalog.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCarter();
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddHealthChecks().AddMongoDb(configuration.GetConnectionString("Database")!);    
        return services;
    }
    
    public static WebApplication UseApiService(this WebApplication app)
    {
        app.MapCarter();
        app.UseExceptionHandler(_=>{});
        app.UseHealthChecks("/health",new HealthCheckOptions
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });
        return app;
    }
}