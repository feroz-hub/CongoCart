using BuildingBlocks.Exceptions;

namespace Catalog.Application.Exceptions;

public class TypeNotFoundException(string id) : NotFoundException("Type not found", id);
