namespace Catalog.Api.CatalogApis.TypesApi;
public record GetAllTypesResponse(IEnumerable<ProductType> Types);

public class GetAllTypes : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/types", async (ISender sender) =>
            {
                var query = new GetAllTypesQuery();
                var result = await sender.Send(query);
                var response = result.Adapt<GetAllTypesResponse>();
                return Results.Ok(response);
            }).WithName("GetAllTypes")
            .Produces<GetAllTypesResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get All Types")
            .WithDescription("Get all product types");
    }
}
