namespace Catalog.Infrastructure.Data;

public static class BrandContextSeed
{
    public static void SeedData(IMongoCollection<ProductBrand> brandCollection)
    {
        var existBrand = brandCollection.Find(b => true).Any();
        var path = Path.Combine(AppContext.BaseDirectory,"Data", "SeedData", "Brands.json");
        if (existBrand) return;
        var brands = File.ReadAllText(path);
        var brandList = JsonSerializer.Deserialize<List<ProductBrand>>(brands);
        brandCollection.InsertMany(brandList);
    }
}