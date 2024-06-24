namespace Catalog.Application.Queries.Types.GetTypeById;

public record GetTypeByIdQuery(string Id) : IQuery<GetTypeByIdResult>;

public record GetTypeByIdResult(ProductType? Type);