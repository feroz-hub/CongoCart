namespace Catalog.Application.Queries.Products.GetProductsByBrand;

public record GetProductsByBrandQuery(string BrandId, int PageNumber = 1, int PageSize = 10) : IQuery<GetProductsByBrandResult>;

public record GetProductsByBrandResult(IEnumerable<Product> Products);