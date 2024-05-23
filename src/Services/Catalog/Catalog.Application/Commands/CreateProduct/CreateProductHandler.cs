namespace Catalog.Application.Commands.CreateProduct;

internal class CreateProductCommandHandler(IProductRepository productRepository):ICommandHandler<CreateProductCommand,CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = command.ProductDto.Adapt<Product>();
        var newProduct= await productRepository.CreateProduct(product);
        return new CreateProductResult(newProduct);
    }
}