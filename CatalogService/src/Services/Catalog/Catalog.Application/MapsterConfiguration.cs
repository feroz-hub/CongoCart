namespace Catalog.Application;

public static class MapsterConfiguration
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<ProductDto, Product>.NewConfig()
            .Map(dest => dest.BrandId, src => src.BrandId)
            .Map(dest => dest.TypeId, src => src.TypeId);
    }
}