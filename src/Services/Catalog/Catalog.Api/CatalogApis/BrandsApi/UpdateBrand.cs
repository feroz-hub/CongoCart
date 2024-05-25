using Catalog.Application.Commands.UpdateBrand;

namespace Catalog.Api.CatalogApis.BrandsApi;
public record UpdateBrandRequest(string Id,string Name, string Description);
public record UpdateBrandResponse(bool IsSuccess);

public class UpdateBrand:ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/brands/{id}", async (string id, UpdateBrandRequest request, ISender sender) =>
            {
                var command = request with { Id = id }; // Ensure the Id from the URL is used
                var result = await sender.Send(command.Adapt<UpdateBrandCommand>());

            var response = result.Adapt<UpdateBrandResponse>();
            return Results.Ok(response);
        }).WithName("UpdateBrand")
        .Produces(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Brand")
        .WithDescription("Update an existing brand");
    }
}