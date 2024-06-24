namespace Catalog.Api.CatalogApis.TypesApi;

public record GetTypeByIdRequest(string Id);
public record GetTypeByIdResponse(ProductType? Type);

public class GetTypeById : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/types/{id}", async (string id, ISender sender) =>
            {
                var query = new GetTypeByIdQuery(id);
                var result = await sender.Send(query);
                var response = result.Adapt<GetTypeByIdResponse>();
                return response.Type == null ? Results.NotFound() : Results.Ok(response);
            }).WithName("GetTypeById")
            .Produces<GetTypeByIdResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Type By ID")
            .WithDescription("Get a product type by its ID");
    }
}
