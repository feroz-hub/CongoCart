namespace Catalog.Infrastructure.Repositories;

public class TypesRepository:ITypesRepository
{
    public async Task<IEnumerable<ProductType>> GetAllTypes()
    {
        throw new NotImplementedException();
    }

    public async Task<ProductType?> GetTypeById(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductType> CreateType(ProductType type)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateType(ProductType type)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteType(string id)
    {
        throw new NotImplementedException();
    }
}