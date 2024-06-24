namespace Catalog.Application.Queries.Products.GetProductsByBrand;

public class GetProductsByBrandQueryHandler(IProductRepository productRepository) : IQueryHandler<GetProductsByBrandQuery, GetProductsByBrandResult>
{
    public async Task<GetProductsByBrandResult> Handle(GetProductsByBrandQuery query, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetProductsByBrand(query.BrandId, query.PageNumber, query.PageSize);
        return new GetProductsByBrandResult(products);
    }
}