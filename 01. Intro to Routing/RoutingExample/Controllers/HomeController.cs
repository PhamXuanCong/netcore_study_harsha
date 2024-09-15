using Microsoft.AspNetCore.Mvc;
using RoutingExample.Model;
using System.Net;
using IServiceContracts;
using RoutingExample.CustomModelBinders;
using RoutingExample.Models;
using Services;
using Person = RoutingExample.Model.Person;
using Person1 = RoutingExample.Models.Person;

namespace RoutingExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitiesService _citiesService1;
        private readonly ICitiesService _citiesService2;
        private readonly ICitiesService _citiesService3;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public HomeController(ICitiesService iCitiesService1, ICitiesService iCitiesService2, ICitiesService iCitiesService3, IServiceScopeFactory serviceScopeFactory)
        {
            _citiesService1 = iCitiesService1;
            _citiesService2 = iCitiesService2;
            _citiesService3 = iCitiesService3;
            _serviceScopeFactory = serviceScopeFactory;
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<string> cities = _citiesService1.GetCities();
            ViewBag.InstanceId_CitiesService_1 = _citiesService1.ServiceInstanceId;

            ViewBag.InstanceId_CitiesService_2 = _citiesService2.ServiceInstanceId;

            ViewBag.InstanceId_CitiesService_3 = _citiesService3.ServiceInstanceId;

            using (IServiceScope scope = _serviceScopeFactory.CreateScope())
            {
                ICitiesService citiesService = scope.ServiceProvider.GetRequiredService<ICitiesService>();

                ViewBag.InstanceId_CitiesServicece_InScope = citiesService.ServiceInstanceId;
            }
            return View(cities);
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
