namespace Catalog.Application.Commands.CreateProduct;

internal class CreateProductCommandHandler(IProductRepository productRepository,IBrandRepository brandRepository,ITypesRepository typesRepository):ICommandHandler<CreateProductCommand,CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // Validate BrandId
        var brand = await brandRepository.GetBrandById(command.BrandId);
        if (brand == null)
        {
            throw new BrandNotFoundException($"Brand with ID {command.BrandId} does not exist.");
        }

        // Validate TypeId
        var type = await typesRepository.GetTypeById(command.TypeId);
        if (type == null)
        {
            throw new TypeNotFoundException($"Type with ID {command.TypeId} does not exist.");
        }
        var product = command.Adapt<Product>();
        var newProduct= await productRepository.CreateProduct(product);
        // Fetch the brand and type details
        newProduct.Brand = brand;
        newProduct.Type = type;
        return new CreateProductResult(newProduct);
    }
}