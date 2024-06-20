using JobFinder.Attributes;
using JobFinder.Core.Contracts;
using JobFinder.Core.Models.Job;
using JobFinder.Infrastructure.Constants;
using JobFinder.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobFinder.Controllers
{
    [Authorize]
    public class JobController : Controller
    {
        private readonly IJobService jobService;
        private readonly IUserService userService;
        private readonly ICategoryService categoryService;
        private readonly IEmploymentTypeService employmentTypeService;
        private readonly ILogger<JobController> logger;

        public JobController(
            IJobService _jobService,
            IUserService _userService,
            ICategoryService _categoryService,
            IEmploymentTypeService _employmentTypeService,
            ILogger<JobController> _logger)
        {
            jobService = _jobService;
            userService = _userService;
            categoryService = _categoryService;
            employmentTypeService = _employmentTypeService;
            logger = _logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Recruiter")]
        [HasCompany]
        public async Task<IActionResult> Create()
        {
            var model = new JobCreateViewModel();

            model.Categories = await categoryService.AllCategoriesAsync();
            model.EmploymentTypes = await employmentTypeService.AllEmploymentTypesAsync();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Recruiter")]
        [HasCompany]
        public async Task<IActionResult> Create(JobCreateViewModel model)
        {
            if (!await categoryService.ExistsAsync(model.CategoryId))
            {
                ModelState.AddModelError(
                    nameof(model.CategoryId),
                    ErrorMessages.CategoryDoesNotExistErrorMessage);
            }

            if (!await employmentTypeService.ExistsAsync(model.EmploymentTypeId))
            {
                ModelState.AddModelError(
                    nameof(model.EmploymentTypeId),
                    ErrorMessages.EmploymentTypeDoesNotExistErrorMessage);
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser user = (await userService.GetUserAsync(User.Id()))!;

            int jobId = await jobService.CreateAsync(model, user.CompanyId ?? 0);

            return RedirectToAction(nameof(Details), new { id = jobId });
        }
    }
}
