using System.Web.Mvc;
using ShopPlus.Models.Brands;
using ShopPlus.Service;
using ShopPlus.Storage;

namespace ShopPlus.Controllers
{
    public class BrandsController : Controller
    {
        public ActionResult Index()
        {
            var service = new BrandsService(new BrandsStorage());

            return View(new BrandsModel
                {
                } );
        }

    }
}
