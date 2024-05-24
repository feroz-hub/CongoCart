namespace Catalog.Application.Queries.Products.GetAllProducts;

public class GetAllProductsQueryHandler(IProductRepository productRepository):IQueryHandler<GetAllProductsQuery,GetAllProductsResult>
{
    public async Task<GetAllProductsResult> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetAllProducts(query.PageNumber ?? 1, query.PageSize);
        return new GetAllProductsResult(products);
    }
}