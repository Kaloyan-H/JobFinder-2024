using JobFinder.Core.Contracts;
using JobFinder.Core.Models.User;
using JobFinder.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static JobFinder.Infrastructure.Constants.RolesEnum;

namespace JobFinder.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IRoleService roleService;
        private readonly ILogger<UserController> logger;

        public UserController(
            UserManager<AppUser> _userManager,
            SignInManager<AppUser> _signInManager,
            RoleManager<AppRole> _roleManager,
            IRoleService _roleService,
            ILogger<UserController> _logger)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
            roleService = _roleService;
            logger = _logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new RegisterViewModel();

            model.Roles = await roleService.AllNormalRolesAsync();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (await roleManager.RoleExistsAsync(model.Role))
            {
                ModelState.AddModelError(nameof(model.Role), "Role does not exist.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new AppUser()
            {
                Bio = model.Bio,
                Email = model.Email,
                UserName = model.UserName,
                LastName = model.LastName,
                FirstName = model.FirstName,
            };

            if (await roleManager.RoleExistsAsync(model.Role) &&
                (model.Role == Recruiter.ToString() || model.Role == JobSeeker.ToString()))
            {
                await userManager.AddToRoleAsync(user, model.Role);
            }
            else
            {
                return View(model);
            }

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("Login", "User");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }

            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.FindByNameAsync(model.UserName);

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid login");

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
