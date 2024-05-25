using Catalog.Application.Commands.UpdateType;

namespace Catalog.Api.CatalogApis.TypesApi;
public record UpdateTypeRequest(string Id, string Name, string Description);
public record UpdateTypeResponse(bool IsSuccess);

public class UpdateType : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/types/{id}", async (string id, UpdateTypeRequest request, ISender sender) =>
            {
                var command = request with { Id = id };
                var result = await sender.Send(command.Adapt<UpdateTypeCommand>());
                return result.IsSuccess ? Results.Ok(new UpdateTypeResponse(true)) : Results.BadRequest(new UpdateTypeResponse(false));
            }).WithName("UpdateType")
            .Produces<UpdateTypeResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Update Type")
            .WithDescription("Update an existing product type");
    }
}
