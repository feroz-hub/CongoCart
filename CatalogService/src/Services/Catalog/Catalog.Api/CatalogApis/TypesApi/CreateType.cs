using Catalog.Application.Commands.CreateType;

namespace Catalog.Api.CatalogApis.TypesApi;
public record CreateTypeRequest(string Name, string Description);
public record CreateTypeResponse(ProductType ProductType);

public class CreateType : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/types", async (CreateTypeRequest request, ISender sender) =>
            {
                var command = request.Adapt<CreateTypeCommand>();
                var result = await sender.Send(command);
                var response = result.Adapt<CreateTypeResponse>();
                return Results.Created($"/types/{response.ProductType.Id}", response);
            }).WithName("CreateType")
            .Produces<CreateTypeResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Type")
            .WithDescription("Create a new product type");
    }
}
