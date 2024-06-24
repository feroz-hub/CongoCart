namespace Catalog.Application.Queries.Brands.GetBrandById;

public class GetBrandByIdQueryHandler(IBrandRepository brandRepository) : IQueryHandler<GetBrandByIdQuery, GetBrandByIdResult>
{
    public async Task<GetBrandByIdResult> Handle(GetBrandByIdQuery query, CancellationToken cancellationToken)
    {
        var brand = await brandRepository.GetBrandById(query.Id);
        if (brand is null)
            throw new BrandNotFoundException(query.Id);
        return new GetBrandByIdResult(brand);
    }
}