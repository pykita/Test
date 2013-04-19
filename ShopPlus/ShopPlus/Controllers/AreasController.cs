using System.Web.Mvc;
using ShopPlus.Storage;
using ShopPlus.Service;
using ShopPlus.Models.Areas;


namespace ShopPlus.Controllers
{
    public class AreasController : Controller
    {
        private readonly IAreasServices m_AreasServices;

        public AreasController()
        {
            m_AreasServices = new AreasService(new AreasStorage());
        }

        public ActionResult Index()
        {
            return View(m_AreasServices.GetAreas());
        }

        public ActionResult Edit(int id)
        {
            return View(m_AreasServices.GetAreaItem(id));
        }

        [HttpPost]
        public ActionResult Edit(AreaItem areaItem)
        {
            if (m_AreasServices.SaveaAreaItem(areaItem))
                return View();
            else
                return null;//ErrorPage - Item wasn't saved
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AreaItem areaItem)
        {
            m_AreasServices.SaveaAreaItem(areaItem);
            return View();
        }
    }
}