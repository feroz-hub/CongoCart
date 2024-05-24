using Catalog.Application.Exceptions;

namespace Catalog.Application.Queries.Products.GetProductById;

public class GetProductByIdQueryHandler(IProductRepository productRepository) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
{
    public async Task<GetProductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await productRepository.GetProductById(query.Id);
        if (product == null)
            throw new ProductNotFoundException(query.Id);
        return new GetProductByIdResult(product);
    }
}