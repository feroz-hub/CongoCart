namespace Catalog.Application.Commands.CreateProduct;

internal class CreateProductCommandHandler(IProductRepository productRepository,IBrandRepository brandRepository,ITypesRepository typesRepository):ICommandHandler<CreateProductCommand,CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = command.Adapt<Product>();
        var newProduct= await productRepository.CreateProduct(product);
        // Fetch the brand and type details
        newProduct.Brand = await brandRepository.GetBrandById(newProduct.BrandId);
        newProduct.Type = await typesRepository.GetTypeById(newProduct.TypeId);
        return new CreateProductResult(newProduct);
    }
}