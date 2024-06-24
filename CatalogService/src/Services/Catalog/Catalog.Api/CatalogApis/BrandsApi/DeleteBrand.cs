namespace Catalog.Api.CatalogApis.BrandsApi;

//public record DeleteBrandRequest(string Id);

public record DeleteBrandResponse(bool IsSuccess);

public class DeleteBrand : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/brands/{id}", async (string id, ISender sender) =>
            {
                var command = new DeleteBrandCommand(id);
                var result = await sender.Send(command);
                return result.IsSuccess ? Results.Ok(new DeleteBrandResponse(result.IsSuccess)) : Results.BadRequest("Failed to delete brand");
            }).WithName("DeleteBrand")
            .Produces<DeleteBrandResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Delete Brand")
            .WithDescription("Delete an existing brand by Id");
    }
}
