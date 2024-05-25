namespace Catalog.Infrastructure.Repositories;

public class TypesRepository(ICatalogContext catalogContext):ITypesRepository
{
    public async Task<IEnumerable<ProductType>> GetAllTypes(CancellationToken cancellationToken)
    {
        return await catalogContext.Types.Find(_ => true).ToListAsync(cancellationToken);
    }

    public async Task<ProductType?> GetTypeById(string id)
    {
        return await catalogContext.Types.Find(type => type.Id == id).FirstOrDefaultAsync();
    }

    public async Task<ProductType?> GetTypeByName(string name)
    {
        return await catalogContext.Types.Find(type => type.Name.ToLower().Contains(name.ToLower())) .FirstOrDefaultAsync();
    }
    public async Task<ProductType> CreateType(ProductType type)
    {
        await catalogContext.Types.InsertOneAsync(type);
        return type;
    }

    public async Task<bool> UpdateType(ProductType type)
    {
        var updateResult = await catalogContext.Types.ReplaceOneAsync(t => t.Id == type.Id, type);
        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    public async Task<bool> DeleteType(string id)
    {
        var deleteResult = await catalogContext.Types.DeleteOneAsync(type => type.Id == id);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }
}