using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
