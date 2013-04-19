using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopPlus.Storage
{
    public interface IAreasStorage : IDisposable
    {
        IQueryable<AreasNew> Areas();
        void AddArea(AreasNew area);
        void DeleteArea(AreasNew area);
        int SaveChanges();
    }
}