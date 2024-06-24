namespace Catalog.Application.Commands.DeleteProduct;


public record DeleteProductCommand(string ProductId) : ICommand<DeleteProductResult>;

public record DeleteProductResult(bool IsSuccess);