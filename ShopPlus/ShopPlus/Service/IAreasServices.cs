using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopPlus.Models.Areas;

namespace ShopPlus.Service
{
    public interface IAreasServices
    {
        AreaModel GetAreas();
        AreaItem GetAreaItem(int id);
        bool DeleteArea(int id);
        bool SaveaAreaItem(AreaItem area);
    }
}