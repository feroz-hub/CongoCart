namespace Catalog.Application.Queries.Products.GetProductsByBrandName;

public record GetProductsByBrandNameQuery(string BrandName, int PageNumber = 1, int PageSize = 10) : IQuery<GetProductsByBrandNameResult>;

public record GetProductsByBrandNameResult(IEnumerable<Product> Products);