namespace Catalog.Api.Endpoints;

public record CreateOrderRequest(ProductDto ProductDto);

public record CreateOrderResponse(Product Product);

public class CreateProduct:ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/product", async (CreateOrderRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateProductCommand>();
            var result = await sender.Send(command);
            var response = result.Adapt<CreateOrderResponse>();
            return Results.Created($"/product/{response.Product.Id}", response);
        }).WithName("CreateProduct")
        .Produces<CreateOrderResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Product")
        .WithDescription("Create Product");
    }
}