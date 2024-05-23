namespace Catalog.Infrastructure.Data;

public static class TypesContextSeed
{
    public static void SeedData(IMongoCollection<ProductType> typesCollection)
    {
        var existBrand = typesCollection.Find(b => true).Any();
        var path = Path.Combine("Data", "SeedData", "Types.json");
        if (existBrand) return;
        var types = File.ReadAllText(path);
        var typesList = JsonSerializer.Deserialize<List<ProductType>>(types);
        typesCollection.InsertMany(typesList);
    }
}