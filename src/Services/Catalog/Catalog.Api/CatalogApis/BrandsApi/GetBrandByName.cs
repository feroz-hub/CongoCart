namespace Catalog.Api.CatalogApis.BrandsApi;

public record GetBrandByNameResponse(ProductBrand? Brand);

public class GetBrandByName : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/brand/name/{name}", async (string name, ISender sender) =>
            {
                var query = new GetBrandByNameQuery(name);
                var result = await sender.Send(query);
                if (result.Brand is null)
                {
                    return Results.NotFound();
                }
                var response = result.Adapt<GetBrandByNameResponse>();
                return Results.Ok(response);
            }).WithName("GetBrandByName")
            .Produces<GetBrandByNameResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Brand By Name")
            .WithDescription("Get brand by name");
    }
}
