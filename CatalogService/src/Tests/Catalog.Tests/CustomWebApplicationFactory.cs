using Catalog.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Catalog.Tests;

public class CustomWebApplicationFactory<TProgram>:WebApplicationFactory<TProgram> where TProgram :class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);
        builder.ConfigureServices(services =>
        {
            services.AddSingleton<IMongoClient, MongoClient>(sp => new MongoClient("mongodb://localhost:27017"));
            services.AddScoped<ICatalogContext, CatalogContext>();
        });

        builder.UseEnvironment("Development");
    }
}