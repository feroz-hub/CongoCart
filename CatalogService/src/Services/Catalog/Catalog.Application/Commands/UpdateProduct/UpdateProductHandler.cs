namespace Catalog.Application.Commands.UpdateProduct;

public class UpdateProductHandler(IProductRepository productRepository):ICommandHandler<UpdateProductCommand,UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        var product=await productRepository.GetProductById(command.Id);
        if (product is null)
            throw new ProductNotFoundException(command.Id);
        // Update product properties
        product.Name = command.Name;
        product.Summary = command.Summary;
        product.Description = command.Description;
        product.ImageFile = command.ImageFile;
        product.Price = command.Price;
        product.BrandId = command.BrandId;
        product.TypeId = command.TypeId;

        // Persist the changes
        var updateResult = await productRepository.UpdateProduct(product);

        // Return result
        return new UpdateProductResult(updateResult);
    }
}