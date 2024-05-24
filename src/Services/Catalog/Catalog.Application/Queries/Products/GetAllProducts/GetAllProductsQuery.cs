namespace Catalog.Application.Queries.Products.GetAllProducts;

public record GetAllProductsQuery(int? PageNumber=1, int PageSize=10):IQuery<GetAllProductsResult>;

public record GetAllProductsResult(IEnumerable<Product> Products);
