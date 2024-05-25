namespace Catalog.Application.Commands.DeleteType;

public class DeleteTypeCommandHandler(ITypesRepository typesRepository) : ICommandHandler<DeleteTypeCommand, DeleteTypeResult>
{
    public async Task<DeleteTypeResult> Handle(DeleteTypeCommand command, CancellationToken cancellationToken)
    {
        var type= await typesRepository.GetTypeById(command.Id);
        if (type is null)
            throw new TypeNotFoundException(command.Id);
        var isDeleted = await typesRepository.DeleteType(command.Id);
        return new DeleteTypeResult(isDeleted);
    }
}
