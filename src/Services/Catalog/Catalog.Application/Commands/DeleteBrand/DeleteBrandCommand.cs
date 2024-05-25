namespace Catalog.Application.Commands.DeleteBrand;
public record DeleteBrandCommand(string Id) : ICommand<DeleteBrandResult>;

public record DeleteBrandResult(bool IsSuccess);

