using JobFinder.Core.Contracts;
using JobFinder.Core.Models.EmploymentType;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Areas.Admin.Controllers
{
    public class EmploymentTypeController : AdminBaseController
    {
        private readonly IEmploymentTypeService employmentTypeService;

        public EmploymentTypeController(IEmploymentTypeService _employmentTypeService)
        {
            employmentTypeService = _employmentTypeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await employmentTypeService.AllAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new EmploymentTypeCreateFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmploymentTypeCreateFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await employmentTypeService.CreateAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await employmentTypeService.ExistsAsync(id))
            {
                return NotFound();
            }

            var model = await employmentTypeService.GetEmploymentTypeEditModelAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmploymentTypeEditFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await employmentTypeService.EditAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await employmentTypeService.ExistsAsync(id))
            {
                return NotFound();
            }

            var model = await employmentTypeService.GetEmploymentTypeDeleteModelAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EmploymentTypeDeleteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.EmploymentTypes = await employmentTypeService.AllExceptAsync(model.Id);

                return View(model);
            }

            await employmentTypeService.DeleteAsync(model.Id, model.NewEmploymentTypeId);

            return RedirectToAction(nameof(All));
        }
    }
}
