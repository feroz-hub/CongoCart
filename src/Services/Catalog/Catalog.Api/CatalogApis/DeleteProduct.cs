using Catalog.Application.Commands.DeleteProduct;

namespace Catalog.Api.CatalogApis;

public record DeleteProductResponse(bool IsSuccess);
public class DeleteProduct : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/product/{productId}", async (string productId, ISender sender) =>
            {
                var result = await sender.Send(new DeleteProductCommand(productId));
                var response = result.Adapt<DeleteProductResponse>();
                return Results.Ok(response);
            }).WithName("DeleteProduct")
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Delete Product")
            .WithDescription("Delete a product by its ID");
    }
}
