namespace Catalog.Core.Entities;

public class ProductBrand:BaseEntity
{
    [BsonElement("Name")]
    public string Name { get; set; } = default!;
    
    [BsonElement("Description")]
    public string Description { get; set; } = default!; // New property for description
    
    [BsonElement("CreatedDate")]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow; // New property for creation date
}