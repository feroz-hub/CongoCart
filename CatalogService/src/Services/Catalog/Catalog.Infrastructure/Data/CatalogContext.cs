namespace Catalog.Infrastructure.Data;

public class CatalogContext:ICatalogContext
{
    public IMongoCollection<Product> Products { get; }
    public IMongoCollection<ProductType> Types { get; }
    public IMongoCollection<ProductBrand> Brands { get; }
    public CatalogContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetConnectionString("Database"));
        var database = client.GetDatabase(configuration.GetConnectionString("DatabaseName"));
        Brands = database.GetCollection<ProductBrand>(configuration.GetConnectionString("BrandsCollection"));
        Types = database.GetCollection<ProductType>(configuration.GetConnectionString("TypesCollection"));
        Products = database.GetCollection<Product>(configuration.GetConnectionString("CollectionName"));
        
        BrandContextSeed.SeedData(Brands);
        TypesContextSeed.SeedData(Types);
        CatalogContextSeed.SeedData(Products);
        
    }
}