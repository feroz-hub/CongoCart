namespace Catalog.Application.Queries.Products.GetProductsByBrandName;

public class GetProductsByBrandNameQueryHandler(IProductRepository productRepository, IBrandRepository brandRepository) : IQueryHandler<GetProductsByBrandNameQuery, GetProductsByBrandNameResult>
{
    public async Task<GetProductsByBrandNameResult> Handle(GetProductsByBrandNameQuery query, CancellationToken cancellationToken)
    {
        var brand = await brandRepository.GetBrandByName(query.BrandName);
        if (brand is null)
        {
            return new GetProductsByBrandNameResult(Enumerable.Empty<Product>());
        }

        var products = await productRepository.GetProductsByBrand(brand.Id, query.PageNumber, query.PageSize);
        return new GetProductsByBrandNameResult(products);
    }
}