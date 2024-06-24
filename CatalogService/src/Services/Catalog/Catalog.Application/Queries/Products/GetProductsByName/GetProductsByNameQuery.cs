namespace Catalog.Application.Queries.Products.GetProductsByName;

public record GetProductsByNameQuery(string Name, int PageNumber = 1, int PageSize = 10) : IQuery<GetProductsByNameResult>;

public record GetProductsByNameResult(IEnumerable<Product> Products);