using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static JobFinder.Constants.AreaConstants;
using static JobFinder.Infrastructure.Constants.RoleConstants;

namespace JobFinder.Areas.Admin.Controllers
{
    [Area(AdminAreaName)]
    [Authorize(Roles = ADMINISTRATOR_ROLE)]
    public class AdminBaseController : Controller
    { }
}
