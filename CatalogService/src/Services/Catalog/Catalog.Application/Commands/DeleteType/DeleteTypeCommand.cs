namespace Catalog.Application.Commands.DeleteType;



public record DeleteTypeCommand(string Id) : ICommand<DeleteTypeResult>;

public record DeleteTypeResult(bool IsSuccess);
