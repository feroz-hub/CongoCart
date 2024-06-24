namespace Catalog.Application.Queries.Brands.GetBrandById;

public record GetBrandByIdQuery(string Id) : IQuery<GetBrandByIdResult>;

public record GetBrandByIdResult(ProductBrand? Brand);