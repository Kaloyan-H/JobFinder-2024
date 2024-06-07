using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Controllers
{
    public class ApplicationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
