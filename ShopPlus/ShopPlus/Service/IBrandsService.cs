using System;
using ShopPlus.Models.Brands;
using ShopPlus.Storage;

namespace ShopPlus.Service
{
    public interface IBrandsService
    {
        BrandsModel GetBrands();
    }

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
            throw new System.NotImplementedException();
        }
    }
}
