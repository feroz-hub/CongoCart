namespace Catalog.Application.Queries.Types.GetAllTypes;

public record GetAllTypesQuery : IQuery<GetAllTypesResult>;

public record GetAllTypesResult(IEnumerable<ProductType> Types);