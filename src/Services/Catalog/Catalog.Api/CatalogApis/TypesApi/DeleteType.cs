using Catalog.Application.Commands.DeleteType;

namespace Catalog.Api.CatalogApis.TypesApi;

public record DeleteTypeRequest(string Id);

public record DeleteTypeResponse(bool IsSuccess);

public class DeleteType : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/types/{id}", async (string id, ISender sender) =>
            {
                var command = new DeleteTypeCommand(id);
                var result = await sender.Send(command);
                return result.IsSuccess ? Results.Ok(new DeleteTypeResponse(result.IsSuccess)) : Results.BadRequest("Failed to delete type");
            }).WithName("DeleteType")
            .Produces<DeleteTypeResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Delete Type")
            .WithDescription("Delete an existing type by Id");
    }
}
