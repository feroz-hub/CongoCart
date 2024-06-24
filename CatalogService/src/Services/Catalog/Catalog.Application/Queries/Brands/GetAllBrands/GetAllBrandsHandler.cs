namespace Catalog.Application.Queries.Brands.GetAllBrands;

public class GetAllBrandsQueryHandler(IBrandRepository brandRepository) : IQueryHandler<GetAllBrandsQuery, GetAllBrandsResult>
{
    public async Task<GetAllBrandsResult> Handle(GetAllBrandsQuery query, CancellationToken cancellationToken)
    {
        var brands = await brandRepository.GetAllBrands(query.PageNumber ?? 1, query.PageSize);
        return new GetAllBrandsResult(brands);
    }
}