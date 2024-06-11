using JobFinder.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Controllers
{
    [Authorize]
    public class JobController : Controller
    {
        private readonly IJobService jobService;

        public JobController(IJobService _jobService)
        {
            jobService = _jobService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
