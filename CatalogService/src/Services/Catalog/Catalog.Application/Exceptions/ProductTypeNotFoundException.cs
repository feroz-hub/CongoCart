using BuildingBlocks.Exceptions;

namespace Catalog.Application.Exceptions;

public class ProductTypeNotFoundException(string id) : NotFoundException("Product type not found", id);
