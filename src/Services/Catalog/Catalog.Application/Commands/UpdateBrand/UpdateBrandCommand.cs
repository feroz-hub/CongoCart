namespace Catalog.Application.Commands.UpdateBrand;

public record UpdateBrandCommand(
    [property: BsonId, BsonRepresentation(BsonType.ObjectId)]
    string Id,
    [property: BsonElement("Name")] string Name,
    string Description) : ICommand<UpdateBrandResult>;
    
    
public record UpdateBrandResult(bool IsSuccess);