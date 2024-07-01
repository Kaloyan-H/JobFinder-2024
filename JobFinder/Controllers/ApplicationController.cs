using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Controllers
{
    public class ApplicationController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
