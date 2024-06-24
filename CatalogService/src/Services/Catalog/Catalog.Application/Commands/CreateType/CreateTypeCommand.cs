namespace Catalog.Application.Commands.CreateType;

public record CreateTypeCommand(string Name, string Description) : ICommand<CreateTypeResult>;

public record CreateTypeResult(ProductType ProductType);