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
            ViewData["ListTitle"] = "Cities";
            ViewData["ListItems"] = new List<string>() {
                "Paris",
                "New York",
                "New Mumbai",
                "Rome"
            };
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("book")]
        public IActionResult Book()
        {
            return View();
        }

        [Route("programming-languages")]
        public IActionResult ProgrammingLanguages()
        {
            ListModel listModel = new ListModel()
            {
                ListTitle = "Programing Langguaes",
                ListItems = new List<string>()
                {
                    "Python",
                    "c#",
                    "Go"
                }
            };
            return PartialView("_ListPartialView", listModel);
        }
    }
}
