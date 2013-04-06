using System.Web.Mvc;
using ShopPlus.Models.Brands;
using ShopPlus.Service;
using ShopPlus.Storage;

namespace ShopPlus.Controllers
{
    public class BrandsController : Controller
    {
        private readonly IBrandsService m_BrandsService;

        public BrandsController()
        {
            m_BrandsService = new BrandsService(new BrandsStorage());
        }

        public ActionResult Index()
        {
            return View(m_BrandsService.GetBrands());
        }

        public ActionResult Edit(int id)
        {
            return View(m_BrandsService.GetBrandItem(id));
        }

        [HttpPost]
        public ActionResult Edit(BrandItem brand)
        {
            m_BrandsService.SaveBrandItem(brand);
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BrandItem brand)
        {
            m_BrandsService.CreateBrand(brand);
            return View();
        }
    }
}
