using BuildingBlocks.Exceptions;

namespace Catalog.Application.Exceptions;

public class ProductNotFoundException(string id) : NotFoundException("Product Not Fount", id);
