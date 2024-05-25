namespace Catalog.Api.CatalogApis.ProductsApi;
public record GetProductsByBrandRequest(string BrandId, int? PageNumber = 1, int PageSize = 10);
public record GetProductsByBrandResponse(IEnumerable<Product> Products);

public class GetProductsByBrand : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/brandId/{brandId}", async ([AsParameters] GetProductsByBrandRequest request, ISender sender) =>
            {
                var query = request.Adapt<GetProductsByBrandQuery>();
                var products = await sender.Send(query);
                var response = products.Adapt<GetProductsByBrandResponse>();
                return Results.Ok(response);
            }).WithName("GetProductsByBrand")
            .Produces<GetProductsByBrandResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products by Brand")
            .WithDescription("Get products by their brand with pagination support");
    }
}
