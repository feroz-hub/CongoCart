using Catalog.Core.Entities;

namespace Catalog.Core.Repositories;

public interface IBrandRepository
{
    Task<IEnumerable<ProductBrand>> GetAllBrands(int pageNumber, int pageSize);
    Task<ProductBrand?> GetBrandById(string id);
    Task<ProductBrand> CreateBrand(ProductBrand brand);
    Task<bool> UpdateBrand(ProductBrand brand);
    Task<bool> DeleteBrand(string id);
    Task<ProductBrand?> GetBrandByName(string name);
}