namespace Catalog.Application.Queries.Types.GetTypeByName;

public record GetTypeByNameQuery(string Name) : IQuery<GetTypeByNameResult>;

public record GetTypeByNameResult(ProductType? Type);