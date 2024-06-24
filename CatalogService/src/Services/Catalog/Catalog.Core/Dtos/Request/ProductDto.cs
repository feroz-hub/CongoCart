namespace Catalog.Core.Dtos.Request;

public record ProductDto(
    string Name,
    string Summary,
    string Description,
    string ImageFile,
    string BrandId,
    string TypeId,
    decimal Price
    );