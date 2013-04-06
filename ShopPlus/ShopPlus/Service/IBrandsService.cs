using ShopPlus.Models.Brands;

namespace ShopPlus.Service
{
    public interface IBrandsService
    {
        BrandsModel GetBrands();
        BrandItem GetBrandItem(int id);
        bool DeleteBrand(int id);
        bool SaveBrandItem(BrandItem brand);
        bool CreateBrand(BrandItem brand);
    }
}
