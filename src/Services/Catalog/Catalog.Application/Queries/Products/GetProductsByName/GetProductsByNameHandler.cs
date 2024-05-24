namespace Catalog.Application.Queries.Products.GetProductsByName;

public class GetProductsByNameQueryHandler(IProductRepository productRepository) : IQueryHandler<GetProductsByNameQuery, GetProductsByNameResult>
{
    public async Task<GetProductsByNameResult> Handle(GetProductsByNameQuery query, CancellationToken cancellationToken)
    {
        var products = await productRepository.GetProductsByName(query.Name, query.PageNumber, query.PageSize);
        return new GetProductsByNameResult(products);
    }
}