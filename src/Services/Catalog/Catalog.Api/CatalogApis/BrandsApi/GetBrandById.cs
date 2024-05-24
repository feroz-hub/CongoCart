namespace Catalog.Api.CatalogApis.BrandsApi;

public record GetBrandByIdResponse(ProductBrand? Brand);

public class GetBrandById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/brand/{id}", async (string id, ISender sender) =>
            {
                var query = new GetBrandByIdQuery(id);
                var result = await sender.Send(query);
                if (result.Brand is null)
                {
                    return Results.NotFound();
                }
                var response = result.Adapt<GetBrandByIdResponse>();
                return Results.Ok(response);
            }).WithName("GetBrandById")
            .Produces<GetBrandByIdResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Brand By Id")
            .WithDescription("Get brand by ID");
    }
}
