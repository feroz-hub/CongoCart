namespace Catalog.Api.CatalogApis.BrandsApi;
public record GetAllBrandsRequest(int? PageNumber, int? PageSize);
public record GetAllBrandsResponse(IEnumerable<ProductBrand> Brands);

public class GetAllBrands : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/brands", async ([AsParameters] GetAllProductsRequest request,ISender sender) =>
            {
                var query = request.Adapt<GetAllBrandsQuery>();
                var result = await sender.Send(query);
                var response = result.Adapt<GetAllBrandsResponse>();
                return Results.Ok(response);
            }).WithName("GetAllBrands")
            .Produces<GetAllBrandsResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get All Brands")
            .WithDescription("Get all brands");
    }
}