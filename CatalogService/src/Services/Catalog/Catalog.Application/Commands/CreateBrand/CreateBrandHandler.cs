namespace Catalog.Application.Commands.CreateBrand;

public class CreateBrandCommandHandler(IBrandRepository brandRepository):ICommandHandler<CreateBrandCommand,CreateBrandResult>
{
    public async Task<CreateBrandResult> Handle(CreateBrandCommand command, CancellationToken cancellationToken)
    {
        var brand=command.Adapt<ProductBrand>();
        var newBrand = await brandRepository.CreateBrand(brand);
        return new CreateBrandResult(newBrand);
    }
}