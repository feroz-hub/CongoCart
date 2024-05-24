namespace Catalog.Api.CatalogApis;

public record GetProductsByNameRequest(string Name, int? PageNumber = 1, int PageSize = 10);
public record GetProductsByNameResponse(IEnumerable<Product> Products);

public class GetProductsByName : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{name}", async ([AsParameters] GetProductsByNameRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetProductsByNameQuery>();
                var products = await sender.Send(query);
                var response = products.Adapt<GetProductsByNameResponse>();
                return Results.Ok(response);
            }).WithName("GetProductsByName")
            .Produces<GetProductsByNameResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products by Name")
            .WithDescription("Get products by their name with pagination support");
    }
}
