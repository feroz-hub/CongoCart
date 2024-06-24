namespace Catalog.Application.Commands.DeleteBrand;

public class DeleteBrandCommandHandler(IBrandRepository brandRepository) : ICommandHandler<DeleteBrandCommand, DeleteBrandResult>
{
    public async Task<DeleteBrandResult> Handle(DeleteBrandCommand command, CancellationToken cancellationToken)
    {
        var isDeleted = await brandRepository.DeleteBrand(command.Id);
        return new DeleteBrandResult(isDeleted);
    }
}