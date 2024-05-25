namespace Catalog.Api.CatalogApis.ProductsApi;

public record GetProductsByBrandNameRequest(string BrandName, int? PageNumber = 1, int PageSize = 10);
public record GetProductsByBrandNameResponse(IEnumerable<Product> Products);

public class GetProductsByBrandName : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/brandName/{brandName}", async ([AsParameters] GetProductsByBrandNameRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetProductsByBrandNameQuery>();
                var products = await sender.Send(query);
                var response = products.Adapt<GetProductsByBrandNameResponse>();
                return Results.Ok(response);
            }).WithName("GetProductsByBrandName")
            .Produces<GetProductsByBrandNameResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products by Brand Name")
            .WithDescription("Get products by their brand name with pagination support");
    }
}
