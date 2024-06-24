namespace Catalog.Application.Commands.UpdateType;

public record UpdateTypeCommand(string Id, string Name, string Description) : ICommand<UpdateTypeResult>;

public record UpdateTypeResult(bool IsSuccess);