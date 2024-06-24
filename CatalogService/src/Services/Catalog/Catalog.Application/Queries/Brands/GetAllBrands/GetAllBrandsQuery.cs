namespace Catalog.Application.Queries.Brands.GetAllBrands;

public record GetAllBrandsQuery(int? PageNumber=1, int PageSize=10) : IQuery<GetAllBrandsResult>;

public record GetAllBrandsResult(IEnumerable<ProductBrand> Brands);