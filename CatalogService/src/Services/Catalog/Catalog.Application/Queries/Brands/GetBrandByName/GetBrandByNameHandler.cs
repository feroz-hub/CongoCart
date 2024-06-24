namespace Catalog.Application.Queries.Brands.GetBrandByName;

public class GetBrandByNameQueryHandler(IBrandRepository brandRepository) : IQueryHandler<GetBrandByNameQuery, GetBrandByNameResult>
{
    public async Task<GetBrandByNameResult> Handle(GetBrandByNameQuery query, CancellationToken cancellationToken)
    {
        var brand = await brandRepository.GetBrandByName(query.Name);
        if (brand is null)
            throw new BrandNotFoundException(query.Name);
        return new GetBrandByNameResult(brand);
    }
}