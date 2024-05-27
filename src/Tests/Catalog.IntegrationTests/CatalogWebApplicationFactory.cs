using Catalog.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using MongoDB.Driver;

namespace Catalog.IntegrationTests;

public class CatalogWebApplicationFactory<TProgram>:WebApplicationFactory<TProgram> where TProgram:class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);
        builder.ConfigureServices(services =>
        {
            services.AddSingleton<IMongoClient, MongoClient>(sp => new MongoClient("mongodb://localhost:27017"));
            services.AddScoped<ICatalogContext, CatalogContext>();
        });

        builder.UseEnvironment("Testing");
    }
}