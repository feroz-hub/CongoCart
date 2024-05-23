namespace Catalog.Infrastructure.Repositories;

public class ProductRepository(ICatalogContext catalogContext):IProductRepository
{
    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        return await catalogContext.Products.Find(_ => true).ToListAsync();
    }

    public async Task<Product?> GetProductById(string id)
    {
        return await catalogContext.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Product> CreateProduct(Product product)
    {
        await catalogContext.Products.InsertOneAsync(product);
        return product;
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        var updateResult = await catalogContext.Products.ReplaceOneAsync(p => p.Id == product.Id, product);
        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
    }
    
    public async Task<bool> DeleteProduct(string id)
    {
        var deleteResult = await catalogContext.Products.DeleteOneAsync(p => p.Id == id);
        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
    }

    public async Task<IEnumerable<Product>> GetProductsByName(string name)
    {
        return await catalogContext.Products.Find(p => p.Name.ToLower().Contains(name.ToLower())).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductsByBrand(string brandId)
    {
        return await catalogContext.Products.Find(p => p.BrandId == brandId).ToListAsync();
    }
}