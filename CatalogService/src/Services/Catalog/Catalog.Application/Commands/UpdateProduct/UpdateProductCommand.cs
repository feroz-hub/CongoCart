namespace Catalog.Application.Commands.UpdateProduct;

public record UpdateProductCommand(
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)] string Id,
    [property: BsonElement("Name")] string Name,
    string Summary,
    string Description,
    string ImageFile,
    decimal Price,
    string BrandId,
    string TypeId
) : ICommand<UpdateProductResult>;

public record UpdateProductResult(bool IsSuccess);