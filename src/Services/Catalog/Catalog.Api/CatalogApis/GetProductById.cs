namespace Catalog.Api.CatalogApis;
public record GetProductByIdRequest(string Id);
public record GetProductByIdResponse(Product Product);

public class GetProductById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/product/{id}", async (string id, ISender sender) =>
            {
                var request = new GetProductByIdRequest(id);
                var query = request.Adapt<GetProductByIdQuery>();
                var result = await sender.Send(query);
                var response = result.Adapt<GetProductByIdResponse>();
                return Results.Ok(response);
            }).WithName("GetProductById")
            .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Get Product by ID")
            .WithDescription("Get a single product by its ID");
    }
}