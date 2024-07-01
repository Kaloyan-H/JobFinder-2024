using JobFinder.Attributes;
using JobFinder.Core.Contracts;
using JobFinder.Core.Models.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JobFinder.Controllers
{
    public class CompanyController : BaseController
    {
        private readonly ICompanyService companyService;
        private readonly IUserService userService;

        public CompanyController(
            ICompanyService _companyService,
            IUserService _userService)
        {
            companyService = _companyService;
            userService = _userService;
        }

        [HttpGet]
        [Authorize(Roles = "Recruiter")]
        [HasCompany]
        public async Task<IActionResult> Index()
        {
            var user = await userService.GetUserAsync(User.Id());

            int companyId = user!.CompanyId ?? 0;

            var model = await companyService.GetCompanyAsync(companyId);

            if (model == null)
            {
                return RedirectToAction(nameof(Create));
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Recruiter")]
        [HasNoCompany]
        public IActionResult Create()
        {
            var model = new CompanyCreateFormModel();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Recruiter")]
        [HasNoCompany]
        public async Task<IActionResult> Create(CompanyCreateFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.Id();
            var companyId = await companyService.CreateAsync(model, userId);

            try
            {
                await userService.AddCompanyAsync(userId, companyId);
            }
            catch (ArgumentException ex)
            {
                throw;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
