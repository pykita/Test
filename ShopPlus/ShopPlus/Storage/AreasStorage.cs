using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopPlus.Storage
{
    public class AreasStorage : IAreasStorage
    {
        private readonly StorageEntity m_StorageEntities;

        public AreasStorage()
        {
            m_StorageEntities = new StorageEntity();
        }

        #region Члены IAreasStorage                     

        public IQueryable<AreasNew> Areas()
        {
            return m_StorageEntities.AreasNew;
        }

        public void AddArea(AreasNew area)
        {
            m_StorageEntities.AreasNew.AddObject(area);
        }

        public void DeleteArea(AreasNew area)
        {
            m_StorageEntities.AreasNew.DeleteObject(area);
        }

        public int SaveChanges()
        {
            return m_StorageEntities.SaveChanges();
        }

        #endregion

        #region Члены IDisposable

        public void Dispose()
        {
            m_StorageEntities.Dispose();
        }

        #endregion
    }
}