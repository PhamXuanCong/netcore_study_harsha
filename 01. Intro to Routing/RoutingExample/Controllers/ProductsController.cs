using Microsoft.AspNetCore.Mvc;

namespace RoutingExample.Controllers
{
    public class ProductsController : Controller
    {
        [Route("products")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("search-products/{ProductID?}")]
        public IActionResult Search(string? ProductID)
        {
            ViewBag.ProductId = ProductID;
            return View();
        }


        [Route("order-product")]
        public IActionResult Order()
        {
            return View();
        }
    }
}
