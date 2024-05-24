
namespace Catalog.Application.Commands.CreateProduct;

public record CreateProductCommand(string Name,
    string Summary,
    string Description,
    string ImageFile,
    string BrandId,
    string TypeId,
    decimal Price) : ICommand<CreateProductResult>;

public record CreateProductResult(Product Product);