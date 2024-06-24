namespace Catalog.Application.Queries.Products.GetProductsByTypeName;

public record GetProductsByTypeNameQuery(string TypeName, int PageNumber = 1, int PageSize = 10) : IQuery<GetProductsByTypeNameResult>;

public record GetProductsByTypeNameResult(IEnumerable<Product> Products);