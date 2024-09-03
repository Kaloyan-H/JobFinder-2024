using JobFinder.Core.Contracts;
using JobFinder.Core.Models.Application;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static JobFinder.Infrastructure.Constants.RoleConstants;

namespace JobFinder.Controllers
{
    public class ApplicationController : BaseController
    {
        private readonly IApplicationService applicationService;
        private readonly IUserService userService;

        public ApplicationController(
            IApplicationService _applicationService,
            IUserService _userService)
        {
            applicationService = _applicationService;
            userService = _userService;
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

        [HttpGet]
        [Authorize(Roles = JOBSEEKER_ROLE)]
        public async Task<IActionResult> Create(int jobId)
        {
            if (await applicationService.AppliedAlreadyAsync(User.Id(), jobId))
            {
                int applicationId = await applicationService.GetApplicationIdAsync(User.Id(), jobId);

                return RedirectToAction(nameof(Details), new { id = applicationId });
            }

            var model = await applicationService.GetApplicationCreateModelAsync(jobId);

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = JOBSEEKER_ROLE)]
        public async Task<IActionResult> Create(ApplicationCreateFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.Id();

            if (userId == null)
            {
                return Unauthorized();
            }

            model.ApplicantId = userId;

            int applicationId = await applicationService.CreateAsync(model);

            return RedirectToAction(nameof(Details), new { id = applicationId });
        }
    }
}
