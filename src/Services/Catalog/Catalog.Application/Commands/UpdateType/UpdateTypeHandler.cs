namespace Catalog.Application.Commands.UpdateType;

public class UpdateTypeCommandHandler(ITypesRepository typeRepository) : ICommandHandler<UpdateTypeCommand, UpdateTypeResult>
{
    public async Task<UpdateTypeResult> Handle(UpdateTypeCommand command, CancellationToken cancellationToken)
    {
        var existingType = await typeRepository.GetTypeById(command.Id);
        if (existingType is null)
        {
            throw new ProductTypeNotFoundException(command.Id);
        }

        existingType.Name = command.Name;
        existingType.Description = command.Description;

        var isUpdated = await typeRepository.UpdateType(existingType);
        return new UpdateTypeResult(isUpdated);
    }
}