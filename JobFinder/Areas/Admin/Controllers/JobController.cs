using JobFinder.Core.Contracts;
using JobFinder.Core.Extensions;
using JobFinder.Core.Models.Job;
using JobFinder.Infrastructure.Constants;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Areas.Admin.Controllers
{
    public class JobController : AdminBaseController
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

        [HttpGet]
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
            query.EmploymentTypes = await employmentTypeService.AllAsync();
            query.Categories = await categoryService.AllAsync();

            return View(query);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string information)
        {
            if (!await jobService.ExistsAsync(id))
            {
                return NotFound();
            }

            try
            {
                JobDetailsViewModel model = await jobService.GetJobDetailsModelAsync(id);

                if (model.GetInformation() != information)
                {
                    return BadRequest();
                }

                return View(model);
            }
            catch (ArgumentException)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await jobService.ExistsAsync(id))
            {
                return NotFound();
            }

            var model = await jobService.GetJobEditModelAsync(id);

            model.Categories = await categoryService.AllAsync();
            model.EmploymentTypes = await employmentTypeService.AllAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(JobEditFormModel model)
        {
            if (!await jobService.ExistsAsync(model.Id))
            {
                return NotFound();
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
                model.Categories = await categoryService.AllAsync();
                model.EmploymentTypes = await employmentTypeService.AllAsync();

                return View(model);
            }

            int jobId = await jobService.EditAsync(model);

            return RedirectToAction(nameof(Details), new { id = jobId, information = model.GetInformation() });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await jobService.ExistsAsync(id))
            {
                return NotFound();
            }

            var model = await jobService.GetJobDeleteModelAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(JobDeleteViewModel model)
        {
            if (!await jobService.ExistsAsync(model.Id))
            {
                return NotFound();
            }

            var success = await jobService.DeleteAsync(model.Id);

            if (!success)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
