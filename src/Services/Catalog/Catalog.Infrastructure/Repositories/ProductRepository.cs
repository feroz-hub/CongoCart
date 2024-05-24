namespace Catalog.Infrastructure.Repositories;

public class ProductRepository(ICatalogContext catalogContext):IProductRepository
{
    public async Task<IEnumerable<Product>> GetAllProducts(int pageNumber,int pageSize)
    {
        var products = await catalogContext.Products
            .Find(_ => true)
            .Skip((pageNumber - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();

        foreach (var product in products)
        {
            product.Brand = await catalogContext.Brands.Find(b => b.Id == product.BrandId).FirstOrDefaultAsync();
            product.Type = await catalogContext.Types.Find(t => t.Id == product.TypeId).FirstOrDefaultAsync();
        }

        return products;
    }

    public async Task<Product?> GetProductById(string id)
    {
        var product= await catalogContext.Products.Find(p => p.Id == id).FirstOrDefaultAsync();
        if (product is null) return null;
        product.Brand = await catalogContext.Brands.Find(b => b.Id == product.BrandId).FirstOrDefaultAsync();
        product.Type = await catalogContext.Types.Find(t => t.Id == product.TypeId).FirstOrDefaultAsync();
        return product;
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

    public async Task<IEnumerable<Product>> GetProductsByName(string name,int? pageNumber,int? pageSize)
    {
        var products= await catalogContext.Products.Find(p => p.Name.ToLower().Contains(name.ToLower())).Skip((pageNumber - 1) * pageSize)
            .Limit(pageSize).ToListAsync();
        foreach (var product in products)
        {
            product.Brand = await catalogContext.Brands.Find(b => b.Id == product.BrandId).FirstOrDefaultAsync();
            product.Type = await catalogContext.Types.Find(t => t.Id == product.TypeId).FirstOrDefaultAsync();
        }

        return products;
    }

    public async Task<IEnumerable<Product>> GetProductsByBrand(string brandId,int? pageNumber,int? pageSize)
    {
        var products= await catalogContext.Products .Find(p => p.BrandId == brandId)
            .Skip((pageNumber - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();
        foreach (var product in products)
        {
            product.Brand = await catalogContext.Brands.Find(b => b.Id == product.BrandId).FirstOrDefaultAsync();
            product.Type = await catalogContext.Types.Find(t => t.Id == product.TypeId).FirstOrDefaultAsync();
        }
        return products;
    }
    public async Task<IEnumerable<Product>> GetProductsByType(string typeId, int? pageNumber, int? pageSize)
    {
        var products= await catalogContext.Products
            .Find(p => p.TypeId == typeId)
            .Skip((pageNumber - 1) * pageSize)
            .Limit(pageSize)
            .ToListAsync();
        foreach (var product in products)
        {
            product.Brand = await catalogContext.Brands.Find(b => b.Id == product.BrandId).FirstOrDefaultAsync();
            product.Type = await catalogContext.Types.Find(t => t.Id == product.TypeId).FirstOrDefaultAsync();
        }
        return products;
    }
}