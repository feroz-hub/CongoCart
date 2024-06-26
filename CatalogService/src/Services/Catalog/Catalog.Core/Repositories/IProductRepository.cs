using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProducts(int pageNumber, int pageSize);
    Task<Product?> GetProductById(string id);
    Task<Product> CreateProduct(Product product);
    Task<bool> UpdateProduct(Product product);
    Task<bool> DeleteProduct(string id);
    Task<IEnumerable<Product>> GetProductsByName(string name, int? pageNumber,int? pageSize);
    Task<IEnumerable<Product>> GetProductsByBrand(string brandId, int? pageNumber,int? pageSize);
    Task<IEnumerable<Product>> GetProductsByType(string typeId, int? pageNumber, int? pageSize);
}