using Catalog.Application.Exceptions;

namespace Catalog.Application.Commands.DeleteProduct;

public class DeleteProductCommandHandler(IProductRepository productRepository) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetProductById(command.ProductId);
        if (product == null)
            throw new ProductNotFoundException(command.ProductId);
        var isSuccess = await productRepository.DeleteProduct(command.ProductId);
        return new DeleteProductResult(isSuccess);
    }
}