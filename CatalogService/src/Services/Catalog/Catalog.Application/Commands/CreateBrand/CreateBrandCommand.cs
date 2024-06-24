namespace Catalog.Application.Commands.CreateBrand;

public record CreateBrandCommand(string Name, string Description) : ICommand<CreateBrandResult>;

public record CreateBrandResult(ProductBrand ProductBrand );