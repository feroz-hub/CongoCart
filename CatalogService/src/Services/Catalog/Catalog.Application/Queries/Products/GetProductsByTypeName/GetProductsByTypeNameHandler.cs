namespace Catalog.Application.Queries.Products.GetProductsByTypeName;

public class GetProductsByTypeNameQueryHandler(IProductRepository productRepository, ITypesRepository typesRepository) : IQueryHandler<GetProductsByTypeNameQuery, GetProductsByTypeNameResult>
{
    public async Task<GetProductsByTypeNameResult> Handle(GetProductsByTypeNameQuery query, CancellationToken cancellationToken)
    {
        var type = await typesRepository.GetTypeByName(query.TypeName);
        if (type is null)
        {
            return new GetProductsByTypeNameResult(Enumerable.Empty<Product>());
        }

        var products = await productRepository.GetProductsByType(type.Id, query.PageNumber, query.PageSize);
        return new GetProductsByTypeNameResult(products);
    }
}