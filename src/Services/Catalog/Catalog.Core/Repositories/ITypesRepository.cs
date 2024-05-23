using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

public interface ITypesRepository
{
    Task<IEnumerable<ProductType>> GetAllTypes();
    Task<ProductType?> GetTypeById(string id);
    Task<ProductType> CreateType(ProductType type);
    Task<bool> UpdateType(ProductType type);
    Task<bool> DeleteType(string id);
}