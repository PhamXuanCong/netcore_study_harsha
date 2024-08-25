using Microsoft.AspNetCore.Mvc;
using RoutingExample.Model;
using System.Net;
using RoutingExample.CustomModelBinders;
using RoutingExample.Models;
using Person = RoutingExample.Model.Person;
using Person1 = RoutingExample.Models.Person;

namespace RoutingExample.Controllers
{
    public class HomeController : Controller
    {

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("about-company")]
        public IActionResult About()
        {
            return View();
        }

        [Route("contact-support")]
        public IActionResult Contract()
        {
            return View();
        }
    }
}
