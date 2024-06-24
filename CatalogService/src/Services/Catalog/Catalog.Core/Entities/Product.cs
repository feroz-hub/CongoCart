namespace Catalog.Core.Entities;

public class Product:BaseEntity
{
    [BsonElement("Name")]
    public string Name { get; set; } = default!;
    
    [BsonElement("Summary")]
    public string Summary { get; set; } = default!;
    
    [BsonElement("Description")]
    public string Description { get; set; } = default!;
    
    [BsonElement("ImageFile")]
    public string ImageFile { get; set; } = default!;
    
    [BsonElement("Brand")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string BrandId { get; set; } = default!;
    
    [BsonElement("Type")]
    [BsonRepresentation(BsonType.ObjectId)]
    public string TypeId { get; set; } = default!;
    
    [BsonIgnore]
    public ProductBrand Brand { get; set; } = default!;
    
    [BsonIgnore]
    public ProductType Type { get; set; } = default!;
    
    [BsonElement("Price")]
    [BsonRepresentation(BsonType.Decimal128)]
    public decimal Price { get; set; }
}

