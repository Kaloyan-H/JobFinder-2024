using JobFinder.Core.Contracts;
using JobFinder.Core.Models.Category;
using Microsoft.AspNetCore.Mvc;

namespace JobFinder.Areas.Admin.Controllers
{
    public class CategoryController : AdminBaseController
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = await categoryService.AllAsync();

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CategoryCreateFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await categoryService.CreateAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await categoryService.ExistsAsync(id))
            {
                return NotFound();
            }

            var model = await categoryService.GetCategoryEditModelAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryEditFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await categoryService.EditAsync(model);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await categoryService.ExistsAsync(id))
            {
                return NotFound();
            }

            var model = await categoryService.GetCategoryDeleteModelAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CategoryDeleteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await categoryService.DeleteAsync(model.Id, model.NewCategoryId);

            return RedirectToAction(nameof(All));
        }
    }
}
