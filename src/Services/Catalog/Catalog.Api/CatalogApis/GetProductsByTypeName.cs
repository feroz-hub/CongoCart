namespace Catalog.Api.CatalogApis;

public record GetProductsByTypeNameRequest(string TypeName, int? PageNumber = 1, int PageSize = 10);
public record GetProductsByTypeNameResponse(IEnumerable<Product> Products);

public class GetProductsByTypeName : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/typeName/{typeName}", async ([AsParameters] GetProductsByTypeNameRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetProductsByTypeNameQuery>();
                var products = await sender.Send(query);
                var response = products.Adapt<GetProductsByTypeNameResponse>();
                return Results.Ok(response);
            }).WithName("GetProductsByTypeName")
            .Produces<GetProductsByTypeNameResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products by Type Name")
            .WithDescription("Get products by their type name with pagination support");
    }
}
