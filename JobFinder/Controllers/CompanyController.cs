using JobFinder.Attributes;
using JobFinder.Core.Contracts;
using JobFinder.Core.Extensions;
using JobFinder.Core.Models.Company;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static JobFinder.Infrastructure.Constants.RoleConstants;

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
        public IActionResult Index()
        {
            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        [Authorize(Roles = $"{RECRUITER_ROLE}, {JOBSEEKER_ROLE}")]
        public async Task<IActionResult> All([FromQuery] AllCompaniesQueryModel query)
        {
            var model = await companyService.AllAsync(query);

            query.TotalCompaniesCount = model.TotalCompaniesCount;
            query.Companies = model.Companies;

            return View(query);
        }

        [HttpGet]
        [Authorize(Roles = RECRUITER_ROLE)]
        [HasCompany]
        public async Task<IActionResult> Mine()
        {
            var user = await userService.GetUserAsync(User.Id());

            int companyId = user!.CompanyId ?? 0;

            var model = await companyService.GetCompanyDetailsModelAsync(companyId);

            if (model == null)
            {
                return RedirectToAction(nameof(Create));
            }

            return RedirectToAction(nameof(Details), new { id = companyId, information = model.GetInformation() });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id, string information)
        {
            if (!await companyService.ExistsAsync(id))
            {
                return NotFound();
            }

            try
            {
                CompanyDetailsViewModel model = await companyService.GetCompanyDetailsModelAsync(id);

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
        [Authorize(Roles = RECRUITER_ROLE)]
        [HasNoCompany]
        public IActionResult Create()
        {
            var model = new CompanyCreateFormModel();

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RECRUITER_ROLE)]
        [HasNoCompany]
        public async Task<IActionResult> Create(CompanyCreateFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = User.Id();

            if (userId == null)
            {
                return BadRequest();
            }

            model.EmployerId = userId;
            var companyId = await companyService.CreateAsync(model);

            try
            {
                await userService.AddCompanyAsync(userId, companyId);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = RECRUITER_ROLE)]
        [HasCompany]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await companyService.ExistsAsync(id))
            {
                return NotFound();
            }

            var model = await companyService.GetCompanyEditModelAsync(id);

            if (!await companyService.CompanyIsOwnedByEmployerAsync(id, User.Id()))
            {
                return Forbid();
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = RECRUITER_ROLE)]
        [HasCompany]
        public async Task<IActionResult> Edit(CompanyEditFormModel model)
        {
            if (!await companyService.ExistsAsync(model.Id))
            {
                return NotFound();
            }

            if (!await companyService.CompanyIsOwnedByEmployerAsync(model.Id, User.Id()))
            {
                return Forbid();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            int companyId = await companyService.EditAsync(model);

            return RedirectToAction(nameof(Details), new { id = companyId, information = model.GetInformation() });
        }

    }
}
