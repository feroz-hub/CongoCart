namespace Catalog.Application.Commands.CreateType;

public class CreateTypeCommandHandler(ITypesRepository typeRepository) : ICommandHandler<CreateTypeCommand, CreateTypeResult>
{
    public async Task<CreateTypeResult> Handle(CreateTypeCommand command, CancellationToken cancellationToken)
    {
        var type = command.Adapt<ProductType>();
        var newType = await typeRepository.CreateType(type);
        return new CreateTypeResult(newType);
    }
}