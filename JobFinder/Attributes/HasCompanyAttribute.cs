using JobFinder.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace JobFinder.Attributes
{
    public class HasCompanyAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var user = context.HttpContext.User;
            IUserService? userService = context.HttpContext.RequestServices.GetService<IUserService>();

            if (userService == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            if (!await userService!.HasCompanyAsync(user.Id()))
            {
                context.Result = new RedirectToActionResult("Create", "Company", null);
            }
            else
            {
                await next();
            }
        }
    }
}
