namespace Catalog.Api.CatalogApis;

public record UpdateProductRequest(
    string Id,
    string Name,
    string Summary,
    string Description,
    string ImageFile,
    string BrandId,
    string TypeId,
    decimal Price);

public record UpdateProductResponse(bool IsSuccess);
public class UpdateProduct:ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/product", async (UpdateProductRequest request, ISender sender) =>
            {
                var command = request.Adapt<UpdateProductCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<UpdateProductResponse>();
                return Results.Ok(response);
            }).WithName("UpdateProduct")
            .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Product")
            .WithDescription("Update an existing product by ID");
    }
}