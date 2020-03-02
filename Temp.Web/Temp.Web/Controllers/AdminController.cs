using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Temp.Web.Controllers
{
    /// <summary>
    /// admin controller
    /// </summary>
    [Authorize]
    public class AdminController : Controller
    {
        /// <summary>
        /// view home admin
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var user = HttpContext.User.Identity.Name;
            return View("Index", user);
        }
    }
}