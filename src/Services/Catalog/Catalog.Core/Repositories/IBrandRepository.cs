using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

public interface IBrandRepository
{
    Task<IEnumerable<ProductBrand>> GetAllBrands();
    Task<ProductBrand?> GetBrandById(string id);
    Task<ProductBrand> CreateBrand(ProductBrand brand);
    Task<bool> UpdateBrand(ProductBrand brand);
    Task<bool> DeleteBrand(string id);
}