using Microsoft.AspNetCore.Mvc;
using RoutingExample.Models;

namespace RoutingExample.ViewComponents
{
    public class GridViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            PersionGridModel personGridModel = new PersionGridModel()
            {
                GridTitle = "Persons List",
                Persons = new List<Person>() {
                    new Person() { PersonName = "John", JobTitle = "Manager" },
                    new Person() { PersonName = "Jones", JobTitle = "Asst. Manager" },
                    new Person() { PersonName = "William", JobTitle = "Clerk" },
                }
            };
            return View("Sample",personGridModel);
        }
    }
}
