var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddInfrastructureServices()
    .AddApplicationServices()
    .AddApiServices(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseApiService();
app.Run();

public partial class Program{}