using JobFinder.Core.Contracts;
using JobFinder.Core.Models.Application;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Areas.Admin.Controllers
{
    public class ApplicationController : AdminBaseController
    {
        private readonly IApplicationService applicationService;

        public ApplicationController(
            IApplicationService _applicationService)
        {
            applicationService = _applicationService;
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!await applicationService.ExistsAsync(id))
            {
                return NotFound();
            }

            ApplicationDetailsViewModel model = await applicationService.GetApplicationDetailsModelAsync(id);

            return View(model);
        }
    }
}
