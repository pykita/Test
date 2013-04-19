using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopPlus.Models.Areas;
using ShopPlus.Storage;

namespace ShopPlus.Service
{
    public class AreasService : IAreasServices
    {
        private readonly IAreasStorage m_Storage;

        public AreasService(IAreasStorage storage)
        {
            if (storage == null)
                throw new ArgumentNullException("storage");

            m_Storage = storage;
        }

        public AreaModel GetAreas()
        {
            return new AreaModel
                {
                    AreaItems = m_Storage.Areas()
                                         .OrderBy(x => x.AreaName)
                                         .Select(x => new AreaItem
                                             {
                                                 Id = x.AreaId,
                                                 AreaName = x.AreaName
                                             })
                                         .ToArray()
                };
        }

        public AreaItem GetAreaItem(int id)
        {
            AreasNew area = m_Storage.Areas().FirstOrDefault(x => x.AreaId == id);

            if (area == null)
                return null;

            return new AreaItem
            {
                Id = area.AreaId,
                AreaName = area.AreaName
            };
        }

        public bool DeleteArea(int id)
        {
            AreasNew area = m_Storage.Areas().FirstOrDefault(x => x.AreaId == id);

            if (area == null)
                return false;

            m_Storage.DeleteArea(area);
            return m_Storage.SaveChanges() > -1;

        }

        public bool SaveaAreaItem(AreaItem area)
        {
            if (area == null)
                return false;

            AreasNew resultArea = null;
            if (area.Id > 0)
            {
                resultArea = m_Storage.Areas()
                                           .FirstOrDefault(x => x.AreaId == area.Id);
            }
            else
                resultArea = new AreasNew();

            if (resultArea != null)
            {
                resultArea.AreaName = area.AreaName;
                if (resultArea.AreaId < 1)
                    m_Storage.AddArea(resultArea);
            }

            return resultArea!=null && m_Storage.SaveChanges() > -1; ;
        }
    }
}