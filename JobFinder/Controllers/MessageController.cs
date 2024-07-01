using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Controllers
{
    public class MessageController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
