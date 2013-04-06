using System;
using System.Linq;

namespace ShopPlus.Storage
{
    public interface IBrandsStorage : IDisposable
    {
        IQueryable<Brands> Brends();
        void AddBrand(Brands brand);
        void DeleteBrand(Brands brand);
        void SaveChanges();
    }
}
