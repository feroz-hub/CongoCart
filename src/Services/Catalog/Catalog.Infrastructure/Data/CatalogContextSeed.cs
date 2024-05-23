namespace Catalog.Infrastructure.Data;

public class CatalogContextSeed
{
    public static void SeedData(IMongoCollection<Product> productCollection)
    {
        var existProduct = productCollection.Find(b => true).Any();
        var path = Path.Combine("Data", "SeedData", "Product.json");
        if (existProduct) return;
        var product = File.ReadAllText(path);
        var productList = JsonSerializer.Deserialize<List<Product>>(product);
        productCollection.InsertMany(productList);
    }
}