namespace Catalog.Api.CatalogApis;

public record GetAllProductsRequest(int? PageNumber, int? PageSize);
public record GetAllProductsResponse(IEnumerable<Product> Products);

public class GetAllProducts:ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async ([AsParameters] GetAllProductsRequest request, ISender sender) =>
        {
            var query=request.Adapt<GetAllProductsQuery>();
            var products=await sender.Send(query);
            var response=products.Adapt<GetAllProductsResponse>();
            return Results.Ok(response);
        }).WithName("GetAllProduct")
        .Produces<GetAllProductsResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get All product")
        .WithDescription("Get All product");
    }
}