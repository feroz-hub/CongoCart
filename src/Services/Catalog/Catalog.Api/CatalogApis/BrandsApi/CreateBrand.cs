using Catalog.Application.Commands.CreateBrand;

namespace Catalog.Api.CatalogApis.BrandsApi;
public record CreateBrandRequest(string Name, string Description);

public record CreateBrandResponse(ProductBrand ProductBrand);

public class CreateBrand : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/brands", async (CreateBrandRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateBrandCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<CreateBrandResponse>();
                return Results.Created($"/brands/{response.ProductBrand.Id}", response);
            }).WithName("CreateBrand")
            .Produces<CreateBrandResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Brand")
            .WithDescription("Create a new brand");
    }
}
