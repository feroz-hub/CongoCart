using BuildingBlocks.Exceptions;

namespace Catalog.Application.Exceptions;

public class BrandNotFoundException(string id) : NotFoundException("Brand Not Found", id);
