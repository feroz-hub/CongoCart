using Catalog.Application.Queries.Types.GetTypeByName;

namespace Catalog.Api.CatalogApis.TypesApi;
public record GetTypeByNameRequest(string Name);
public record GetTypeByNameResponse(ProductType? Type);

public class GetTypeByName : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/types/name/{name}", async (string name, ISender sender) =>
            {
                var query = new GetTypeByNameQuery(name);
                var result = await sender.Send(query);
                var response = result.Adapt<GetTypeByNameResponse>();
                if (response.Type == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(response);
            }).WithName("GetTypeByName")
            .Produces<GetTypeByNameResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Type By Name")
            .WithDescription("Get a product type by its name");
    }
}
