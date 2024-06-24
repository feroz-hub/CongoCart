namespace Catalog.Application.Queries.Products.GetProductById;


public record GetProductByIdQuery(string Id) : IQuery<GetProductByIdResult>;

public record GetProductByIdResult(Product Product);