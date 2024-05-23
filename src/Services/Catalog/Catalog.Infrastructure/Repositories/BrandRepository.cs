namespace Catalog.Infrastructure.Repositories;

public class BrandRepository(ICatalogContext catalogContext):IBrandRepository
{
    public async Task<IEnumerable<ProductBrand>> GetAllBrands()
    {
        return await catalogContext.Brands.Find(_ => true).ToListAsync();
    }

    public async Task<ProductBrand?> GetBrandById(string id)
    {
        return await catalogContext.Brands.Find(brand => brand.Id == id).FirstOrDefaultAsync();
    }

    public async Task<ProductBrand> CreateBrand(ProductBrand brand)
    {
        await catalogContext.Brands.InsertOneAsync(brand);
        return brand;
    }

    public async Task<bool> UpdateBrand(ProductBrand brand)
    {
        var updateResult = await catalogContext.Brands.ReplaceOneAsync(b => b.Id == brand.Id, brand);
        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }

    public async Task<bool> DeleteBrand(string id)
    {
        var deleteResult = await catalogContext.Brands.DeleteOneAsync(brand => brand.Id == id);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }
}