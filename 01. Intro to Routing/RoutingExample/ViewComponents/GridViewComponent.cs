using Microsoft.AspNetCore.Mvc;

namespace RoutingExample.ViewComponents
{
    public class GridViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("Sample");
        }
    }
}
