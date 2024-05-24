using Catalog.Application.Exceptions;

namespace Catalog.Application.Commands.UpdateBrand;

public class UpdateBrandHandler(IBrandRepository brandRepository):ICommandHandler<UpdateBrandCommand,UpdateBrandResult>
{
    public async Task<UpdateBrandResult> Handle(UpdateBrandCommand command, CancellationToken cancellationToken)
    {
        var brand = await brandRepository.GetBrandById(command.Id);
        if (brand is null)
            throw new BrandNotFoundException(command.Id);

        brand.Name = command.Name;
        brand.Description = command.Description;
        var updateResult = await brandRepository.UpdateBrand(brand);
        return new UpdateBrandResult(updateResult);
    }
}