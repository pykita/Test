using System;
using System.Linq;
using ShopPlus.Models.Brands;
using ShopPlus.Storage;

namespace ShopPlus.Service
{
    public class BrandsService : IBrandsService
    {
        private readonly IBrandsStorage m_Storage;

        public BrandsService(IBrandsStorage storage)
        {
            if (storage == null)
                throw new ArgumentNullException("storage");

            m_Storage = storage;
        }

        public BrandsModel GetBrands()
        {
            return new BrandsModel
                {
                    BrandItems = m_Storage.Brands()
                                          .OrderBy(x => x.BrandName)
                                          .Select(x => new BrandItem
                                              {
                                                  Name = x.BrandName,
                                                  Id = x.BrandId
                                              })
                                          .ToArray()
                };
        }

        public bool DeleteBrand(int id)
        {
            var brand = m_Storage.Brands().FirstOrDefault(x => x.BrandId == id);

            if (brand == null)
                return false;

            m_Storage.DeleteBrand(brand);
            m_Storage.SaveChanges();
            return true;
        }

        public BrandItem GetBrandItem(int id)
        {
            var brand = m_Storage.Brands().FirstOrDefault(x => x.BrandId == id);

            if (brand == null)
                return null;

            return new BrandItem
                {
                    Id = brand.BrandId,
                    Name = brand.BrandName
                };
        }

        public bool SaveBrandItem(BrandItem brand)
        {
            if (brand == null)
                return false;

            var oldBrand = m_Storage.Brands()
                                    .FirstOrDefault(x => x.BrandId == brand.Id);

            if (oldBrand == null)
                return false;

            oldBrand.BrandName = brand.Name;
            m_Storage.SaveChanges();
            return true;
        }

        public bool CreateBrand(BrandItem brand)
        {
            if (brand == null)
                return false;
            
            m_Storage.AddBrand(new Brands
                {
                    BrandName = brand.Name
                });
            m_Storage.SaveChanges();
            return true;
        }
    }
}