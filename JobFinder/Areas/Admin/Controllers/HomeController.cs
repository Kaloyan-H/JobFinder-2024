using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
