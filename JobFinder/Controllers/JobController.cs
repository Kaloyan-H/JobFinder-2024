using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Controllers
{
    [Authorize]
    public class JobController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
