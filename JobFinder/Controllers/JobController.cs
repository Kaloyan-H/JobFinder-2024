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
    public class JobController : BaseController
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
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllJobsQueryModel query)
        {
            var model = await jobService.AllAsync(query);

            query.TotalJobsCount = model.TotalJobsCount;
            query.Jobs = model.Jobs;
            query.EmploymentTypes = await employmentTypeService.AllEmploymentTypesAsync();
            query.Categories = await categoryService.AllCategoriesAsync();

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!await jobService.ExistsAsync(id))
            {
                return NotFound();
            }

            JobDetailsViewModel model = await jobService.GetJobDetailsModelAsync(id);

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Recruiter")]
        [HasCompany]
        public async Task<IActionResult> Create()
        {
            var model = new JobCreateFormModel();

            model.Categories = await categoryService.AllCategoriesAsync();
            model.EmploymentTypes = await employmentTypeService.AllEmploymentTypesAsync();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Recruiter")]
        [HasCompany]
        public async Task<IActionResult> Create(JobCreateFormModel model)
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

            int companyId = user.CompanyId ?? 0;

            if (companyId == 0)
            {
                return RedirectToAction("Create", "Company");
            }

            model.CompanyId = companyId;

            int jobId = await jobService.CreateAsync(model);

            return RedirectToAction(nameof(Details), new { id = jobId });
        }

        [HttpGet]
        [Authorize(Roles = "Recruiter")]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await jobService.ExistsAsync(id))
            {
                return NotFound();
            }

            var model = await jobService.GetJobEditModelAsync(id);

            if (model.EmployerId != User.Id())
            {
                return Forbid();
            }

            model.Categories = await categoryService.AllCategoriesAsync();
            model.EmploymentTypes = await employmentTypeService.AllEmploymentTypesAsync();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Recruiter")]
        public async Task<IActionResult> Edit(JobEditFormModel model)
        {
            if (!await jobService.ExistsAsync(model.Id))
            {
                return NotFound();
            }

            if (model.EmployerId != User.Id())
            {
                return Forbid();
            }

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
                model.Categories = await categoryService.AllCategoriesAsync();
                model.EmploymentTypes = await employmentTypeService.AllEmploymentTypesAsync();

                return View(model);
            }

            int jobId = await jobService.EditJobAsync(model);

            return RedirectToAction(nameof(Details), new { id = jobId });
        }
    }
}
