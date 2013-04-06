using System.Linq;

namespace ShopPlus.Storage
{
    public class BrandsStorage : IBrandsStorage
    {
        private readonly StorageEntity m_StorageEntities;

        public BrandsStorage()
        {
            m_StorageEntities = new StorageEntity();
        }

        public void Dispose()
        {
            m_StorageEntities.Dispose();
        }

        public IQueryable<Brands> Brends()
        {
            return m_StorageEntities.Brands;
        }

        public void AddBrand(Brands brand)
        {
            m_StorageEntities.Brands.AddObject(brand);
        }

        public void DeleteBrand(Brands brand)
        {
            m_StorageEntities.Brands.DeleteObject(brand);
        }

        public void SaveChanges()
        {
            m_StorageEntities.SaveChanges();
        }
    }
}